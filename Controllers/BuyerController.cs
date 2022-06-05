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
    public class BuyersController : Controller
    {
        private readonly DataContext _context;

        public BuyersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Buyer>>> Get()
        {
            return Ok(await _context.Buyers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Buyer>> Get(long id)
        {
            var buyer = await _context.Buyers.FindAsync(id);
            if (buyer == null)
                return BadRequest("Buyer not found");
            return Ok(buyer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Buyer>>> AddBuyer(Buyer buyer)
        {
            _context.Buyers.Add(buyer);
            await _context.SaveChangesAsync();
            return Ok(await _context.Buyers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Buyer>>> UpdateBuyer(Buyer request)
        {
            var Dbbuyer = await _context.Buyers.FindAsync(request.Id);
            if (Dbbuyer == null)
                return BadRequest("Buyer not found");

            Dbbuyer.Name = request.Name;
            await _context.SaveChangesAsync();

            return Ok(await _context.Buyers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Buyer>>> Delete(long id)
        {
            var buyer = await _context.Buyers.FindAsync(id);
            if (buyer == null)
                return BadRequest("Buyer not found");

            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();

            return Ok(await _context.Buyers.ToListAsync());
        }
    }
}
