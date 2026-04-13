using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopEZ.DTOs.Product;
using ShopEZ.Services.Interfaces;

namespace ShopEZ.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
            => _productService = productService;

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(new
            {
                message = products.Any()
                    ? "Products retrieved successfully"
                    : "No products available",

                count = products.Count(),
                data = products
            });
        }

        // GET BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product is null)
                return NotFound(new
                {
                    message = "Product not found"
                });

            return Ok(new
            {
                message = "Product fetched successfully",
                data = product
            });
        }

        // CREATE (ADMIN ONLY)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    message = "Invalid product data",
                    errors = ModelState
                });

            var product = await _productService.CreateProductAsync(dto);

            return Ok(new
            {
                message = "Product created successfully",
                data = product
            });
        }

        // UPDATE (ADMIN ONLY)
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateProductDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    message = "Invalid update data",
                    errors = ModelState
                });

            var product = await _productService.UpdateProductAsync(id, dto);

            if (product is null)
                return NotFound(new
                {
                    message = "Product not found"
                });

            return Ok(new
            {
                message = "Product updated successfully",
                data = product
            });
        }

        // DELETE (ADMIN ONLY)
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Product not found"
                });

            return Ok(new
            {
                message = "Product deleted successfully from catalog"
            });
        }
    }
}
