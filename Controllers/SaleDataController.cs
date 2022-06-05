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
    public class SaleDataController : Controller
    {
        private readonly DataContext _context;

        public SaleDataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SaleData>>> Get()
        {
            return Ok(await _context.SalesData.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleData>> Get(long? id)
        {
            var saledata = await _context.SalesData.FindAsync(id);
            if (saledata == null)
                return BadRequest("SaleData not found");
            return Ok(saledata);
        }

        [HttpPost]
        public async Task<ActionResult<List<SaleData>>> AddSaleData(SaleData data)
        {
            _context.SalesData.Add(data);
            await _context.SaveChangesAsync();
            return Ok(await _context.SalesData.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SaleData>>> UpdateSaleData(SaleData request)
        {
            var DbSaleData = await _context.SalesData.FindAsync(request.Id);
            if (DbSaleData == null)
                return BadRequest("Product not found");

            DbSaleData.ProductId = request.ProductId;
            DbSaleData.ProductQuantity = request.ProductQuantity;
            DbSaleData.ProductIdAmount = request.ProductIdAmount;
            DbSaleData.SaleId = request.SaleId;
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SaleData>>> Delete(long id)
        {
            var saleData = await _context.SalesData.FindAsync(id);
            if (saleData == null)
                return BadRequest("Product not found");

            _context.SalesData.Remove(saleData);
            await _context.SaveChangesAsync();

            return Ok(await _context.SalesData.ToListAsync());
        }
    }
}
