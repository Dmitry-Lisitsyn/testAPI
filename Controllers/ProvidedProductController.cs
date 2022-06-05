using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testAPI.Data;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidedProductController : Controller
    {
        private readonly DataContext _context;

        public ProvidedProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProvidedProduct>>> Get()
        {
            return Ok(await _context.ProvidedProducts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProvidedProduct>> Get(long id)
        {
            var provProduct = await _context.ProvidedProducts.FindAsync(id);
            if (provProduct == null)
                return BadRequest("Products not found");
            return Ok(provProduct);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProvidedProduct>>> AddProducts(ProvidedProduct products)
        {
            _context.ProvidedProducts.Add(products);
            await _context.SaveChangesAsync();
            return Ok(await _context.ProvidedProducts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ProvidedProduct>>> UpdateProducts(ProvidedProduct request)
        {
            var DbProducts = await _context.ProvidedProducts.FindAsync(request.Id);  
            if (DbProducts == null)
                return BadRequest("Products not found");

            DbProducts.ProductQuantity = request.ProductQuantity;
            await _context.SaveChangesAsync();

            return Ok(await _context.ProvidedProducts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProvidedProduct>>> Delete(long id)
        {
            var products = await _context.ProvidedProducts.FindAsync(id);
            
            if (products == null)
                return BadRequest("SalePoint not found");

            _context.ProvidedProducts.Remove(products);
            await _context.SaveChangesAsync();

            return Ok(await _context.ProvidedProducts.ToListAsync());
        }
    }
}
