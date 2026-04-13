using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopEZ.DTOs.Order;
using ShopEZ.Services.Interfaces;
using System.Security.Claims;

namespace ShopEZ.Controllers
{
    [ApiController]
    [Route("api/orders")]
    [Authorize] 
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    message = "Invalid order request",
                    errors = ModelState
                });

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var order = await _orderService.CreateOrderAsync(dto, int.Parse(userId));

            return Ok(new
            {
                message = "Order placed successfully",
                data = order
            });
        }

        
        [HttpGet("my-orders")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetMyOrders()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var orders = await _orderService.GetOrdersByUserIdAsync(int.Parse(userId));

            return Ok(new
            {
                message = orders.Any()
                    ? "Your orders retrieved successfully"
                    : "No orders found",
                count = orders.Count(),
                data = orders
            });
        }

        [HttpGet("all-orders")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            return Ok(new
            {
                message = orders.Any()
                    ? "All orders retrieved successfully"
                    : "No orders found",
                count = orders.Count(),
                data = orders
            });
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order is null)
                return NotFound(new
                {
                    message = "Order not found"
                });

            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Customer can only see their own order
            if (role == "Customer" && order.UserId.ToString() != userId)
                return Forbid();

            return Ok(new
            {
                message = "Order details fetched successfully",
                data = order
            });
        }
    }
}
