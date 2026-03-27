using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Domain;

namespace Products.API.Controllers
{

    [ApiController]
    [Route("api/products")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? colour)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(colour))
                query = query.Where(p => p.Colour == colour);

            var products = await query.ToListAsync();
            return Ok(products);
        }
    }
}
