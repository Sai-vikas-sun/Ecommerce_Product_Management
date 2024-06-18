using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductStore.Controllers.DTO;
using ProductStore.Models;
using System;

namespace ProductStore.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

       /* [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            //IEnumerable<Product> products =  ().ToList();

            return Ok((_context.Products));

        }
       */
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }





        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] AddProductRequest productRequest)
        {
            Product product = productRequest.ConvertToProduct(productRequest);

            /*await _context.Products.AddAsync(product);

            return Ok(product);*/

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid Id, Product product)
        {

           /*Guid Id;
            try
            {
                Id = new Guid(id);
            }
            catch
            {
                //Id = Guid.Empty;

                 return BadRequest();
            }*/
            if (Id != product.ProductId)
            {
                return BadRequest();
            }

            Product? existProduct = await _context.Products.FindAsync(Id);
            if (existProduct == null)
            {
                return BadRequest();
            }

            existProduct.ProductName = product.ProductName;
            existProduct.Price = product.Price;
            existProduct.Description = product.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch 
            {

                return BadRequest();
                
            }

            return NoContent();
        }

       /* private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }*/




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            Guid Id;
            try
            {
                Id = new Guid(id);
            }
            catch
            {
                //Id = Guid.Empty;

                return BadRequest();
            }
            var product = await _context.Products.FindAsync(Id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }





    }
}
