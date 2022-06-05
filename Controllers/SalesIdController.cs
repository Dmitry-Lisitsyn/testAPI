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
    public class SalesIdController : Controller
    {
        private readonly DataContext _context;

        public SalesIdController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalesId>>> Get()
        {
            return Ok(await _context.SalesIds.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesId>> Get(long id)
        {
            var salesId = await _context.SalesIds.FindAsync(id);
            if (salesId == null)
                return BadRequest("SaleId not found");
            return Ok(salesId);
        }

        [HttpPost]
        public async Task<ActionResult<List<SalesId>>> AddSaleId(SalesId saleId)
        {
            _context.SalesIds.Add(saleId);
            await _context.SaveChangesAsync();
            return Ok(await _context.SalesPoints.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SalesId>>> UpdateSaleId(SalesId request)
        {
            var DbSaleId = await _context.SalesIds.FindAsync(request.Id);
            if (DbSaleId == null)
                return BadRequest("SaleId not found");

            DbSaleId.BuyerId  = request.BuyerId;
            DbSaleId.SaleId  = request.SaleId;
            await _context.SaveChangesAsync();

            return Ok(await _context.SalesIds.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SalesId>>> Delete(long id)
        {
            var SaleId = await _context.SalesIds.FindAsync(id);
            if (SaleId == null)
                return BadRequest("SalePoint not found");

            _context.SalesIds.Remove(SaleId);
            await _context.SaveChangesAsync();

            return Ok(await _context.SalesIds.ToListAsync());
        }
    }
}
