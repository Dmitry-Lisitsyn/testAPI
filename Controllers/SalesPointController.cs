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
    public class SalesPointController : Controller
    {
        private readonly DataContext _context;

        public SalesPointController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalesPoint>>> Get()
        {
            return Ok(await _context.SalesPoints.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesPoint>> Get(long id)
        {
            var salesPoint = await _context.SalesPoints.FindAsync(id);
            if (salesPoint == null)
                return BadRequest("SalePoint not found");
            return Ok(salesPoint);
        }

        [HttpPost]
        public async Task<ActionResult<List<SalesPoint>>> AddSalePoint(SalesPoint salesPoint)
        {
            _context.SalesPoints.Add(salesPoint);
            await _context.SaveChangesAsync();
            return Ok(await _context.SalesPoints.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SalesPoint>>> UpdateSalePoint(SalesPoint request)
        {
            var DbSalePoint = await _context.SalesPoints.FindAsync(request.Id);
            if (DbSalePoint == null)
                return BadRequest("SalePoint not found");

            DbSalePoint.Name = request.Name;
            await _context.SaveChangesAsync();

            return Ok(await _context.SalesPoints.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SalesPoint>>> Delete(int id)
        {
            var SalePoint = await _context.SalesPoints.FindAsync(id);
            if (SalePoint == null)
                return BadRequest("SalePoint not found");

            _context.SalesPoints.Remove(SalePoint);
            await _context.SaveChangesAsync();

            return Ok(await _context.SalesPoints.ToListAsync());
        }
    }
}
