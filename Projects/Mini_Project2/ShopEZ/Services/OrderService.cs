using System.Security.Claims;
using ShopEZ.Data;
using ShopEZ.DTOs.Order;
using ShopEZ.Models;
using ShopEZ.Repositories.Interfaces;
using ShopEZ.Services.Interfaces;

namespace ShopEZ.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ApplicationDbContext _context;

        public OrderService(
            IOrderRepository orderRepo,
            ApplicationDbContext context)
        {
            _orderRepo = orderRepo;
            _context = context;
        }
        public async Task<OrderResponseDTO> CreateOrderAsync(CreateOrderDTO dto, int userId)
        {
            if (dto.CartItems == null || !dto.CartItems.Any())
                throw new ArgumentException("Cart cannot be empty.");

            var orderItems = new List<OrderItem>();

            foreach (var item in dto.CartItems)
            {
                if (item.Quantity <= 0)
                    throw new ArgumentException($"Quantity must be greater than 0.");

                var product = await _context.Products.FindAsync(item.ProductId)
                    ?? throw new KeyNotFoundException($"Product {item.ProductId} not found.");

                if (product.Stock < item.Quantity)
                    throw new InvalidOperationException(
                        $"Only {product.Stock} items available for '{product.Name}'.");

                // reduce stock
                product.Stock -= item.Quantity;

                orderItems.Add(new OrderItem
                {
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price
                });
            }

            decimal totalAmount = orderItems.Sum(x => x.Price * x.Quantity);

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = totalAmount,
                OrderItems = orderItems
            };

            var created = await _orderRepo.CreateAsync(order);

            return MapToDTO(created);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.GetAllAsync();
            return orders.Select(MapToDTO);
        }

        public async Task<OrderResponseDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            return order is null ? null : MapToDTO(order);
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepo.GetAllAsync();

            var userOrders = orders.Where(o => o.UserId == userId);

            return userOrders.Select(MapToDTO);
        }
        private static OrderResponseDTO MapToDTO(Order o) => new()
        {
            OrderId = o.OrderId,
            UserId = o.UserId,
            OrderDate = o.OrderDate,
            TotalAmount = o.TotalAmount,
            Items = o.OrderItems.Select(oi => new OrderItemResponseDTO
            {
                ProductId = oi.ProductId,
                ProductName = oi.Product?.Name ?? "Unknown",
                Quantity = oi.Quantity,
                Price = oi.Price
            }).ToList()
        };
    }
}
