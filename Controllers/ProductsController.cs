using Backend.Context;
using Backend.Dtos;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //CRUD

        //Create
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProductDto dto)
        {
            var newProduct = new ProductEntity()

            {
                brand = dto.brand,
                title = dto.title,
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return Ok("Product Saved Successfully");
        }

        //Read
        [HttpGet]
        public async Task<ActionResult<ProductEntity>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductByID([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.id == id);

            if(product is null)
            {
                return NotFound("Product Not Found");
            }

            return Ok(product);
        }

        //Update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductByID([FromRoute] long id, [FromBody] CreateUpdateProductDto dto)
        {

            var product = await _context.Products.FirstOrDefaultAsync(q => q.id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            product.title = dto.title;
            product.brand = dto.brand;
            product.updatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok("Product Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok("Product delete successfully");
        }

    }


}
