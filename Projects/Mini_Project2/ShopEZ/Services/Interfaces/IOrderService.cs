using ShopEZ.DTOs.Order;

namespace ShopEZ.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> CreateOrderAsync(CreateOrderDTO dto, int userId);

        Task<IEnumerable<OrderResponseDTO>> GetAllOrdersAsync();

        Task<OrderResponseDTO?> GetOrderByIdAsync(int id);

        Task<IEnumerable<OrderResponseDTO>> GetOrdersByUserIdAsync(int userId);
    }
}
