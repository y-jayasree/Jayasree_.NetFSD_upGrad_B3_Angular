using Microsoft.AspNetCore.Mvc;
using WebApplication15.Models;
using WebApplication15.Services;

namespace WebApplication15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _service.Add(category);
            return Ok("Category Added");
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            _service.Update(category);
            return Ok("Category Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Category Deleted");
        }
    }
}
