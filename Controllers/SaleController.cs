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
    public class SaleController : Controller
    {
        private readonly DataContext _context;

        public SaleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sale>>> Get()
        {
            return Ok(await _context.Sales.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> Get(long id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
                return BadRequest("Sale not found");
            return Ok(sale);
        }

        private bool validateAttributes(SaleCreate newSale)
        {
            if (_context.Products.Find(newSale.ProductId) == null)
                return false;
            if (_context.SalesPoints.Find(newSale.SalesPointId) == null)
                return false;
            return true;
        }

        [HttpPost("CreateSale")]
        public async Task<ActionResult<List<Sale>>> CreateSale(SaleCreate newSale)
        {
            if (!validateAttributes(newSale))
                return BadRequest("Ошибка введенных данных");

            Sale saleToAdd = new Sale();
            SaleData saleDataToAdd = new SaleData();
            
            string saleDate = DateTime.Today.ToString("dd/MM/yyyy");
            string saleTime = DateTime.Now.ToString("HH:mm");

            //перечень товаров у магазина
            var provProduct = _context.ProvidedProducts
                .Where(x => x.SalePointId == newSale.SalesPointId)
                .FirstOrDefault(x => x.ProductId == newSale.ProductId);
           
            if(provProduct == null ||
                (provProduct.ProductQuantity < newSale.ProductQuantity) ||
                (provProduct.ProductQuantity == 0))
                return BadRequest("В выбранном магазине нет выбранного товара");

            //изменение кол-ва продуктов
            provProduct.ProductQuantity = provProduct.ProductQuantity - newSale.ProductQuantity;

            //стоимость
            var totalAmount = newSale.ProductQuantity * ((_context.Products
                .Find(newSale.ProductId)).Price);
            
            //формирование покупки
            saleToAdd.Date = saleDate;
            saleToAdd.Time = saleTime;
            saleToAdd.SalesPointId = newSale.SalesPointId;
            saleToAdd.BuyerId = newSale.BuyerId;
            saleToAdd.TotalAmount = totalAmount;
            await _context.Sales.AddAsync(saleToAdd);
            await _context.SaveChangesAsync();

            ////данные о покупке
            saleDataToAdd.ProductId = newSale.ProductId;
            saleDataToAdd.ProductQuantity = newSale.ProductQuantity;
            saleDataToAdd.ProductIdAmount = totalAmount;
            saleDataToAdd.SaleId = saleToAdd.Id;
            await _context.SalesData.AddAsync(saleDataToAdd);

            if (newSale.BuyerId != null)
            {
                SalesId saleIdsToAdd = new SalesId();
                saleIdsToAdd.BuyerId = newSale.BuyerId;
                saleIdsToAdd.SaleId = saleToAdd.Id;
                await _context.SalesIds.AddAsync(saleIdsToAdd);
            }

            await _context.SaveChangesAsync();
            return Ok(await _context.Sales.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Sale>>> UpdateSale(Sale request)
        {
            var DbSale = await _context.Sales.FindAsync(request.Id);
            if (DbSale == null)
                return BadRequest("Sale not found");

            DbSale.Date = request.Date;
            DbSale.Time = request.Time;
            DbSale.SalesPointId = request.SalesPointId;
            DbSale.BuyerId = request.BuyerId;
            await _context.SaveChangesAsync();

            return Ok(await _context.Sales.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Sale>>> Delete(int id)
        {
            var Sale = await _context.Sales.FindAsync(id);
            if (Sale == null)
                return BadRequest("SalePoint not found");

            _context.Sales.Remove(Sale);
            await _context.SaveChangesAsync();

            return Ok(await _context.Sales.ToListAsync());
        }
    }
}
