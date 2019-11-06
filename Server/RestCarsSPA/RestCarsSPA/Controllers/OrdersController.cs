using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestCarsSPA;
using RestCarsSPA.BL;

namespace RestCarsSPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly RestCarsDBContext _context;

        public OrdersController(RestCarsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("byDriver/{driverName}")]
        public ActionResult<IEnumerable<Orders>> GetOrdersByDriverName(string driverName)
        {
            var orderMethods = new OrderMethods(_context);
            return orderMethods.GetOrderListByDriverName(driverName);
        }

        [HttpGet("date/startDate/{date}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrdersByStartDate(string date)
        {
            return await _context.Orders.Where(order=>order.StartDate == DateTime.Parse(date)).ToListAsync();
        }

        [HttpGet("date/endDate/{date}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrdersByEndDate(string date)
        {
            return await _context.Orders.Where(order => order.EndDate == DateTime.Parse(date)).ToListAsync();
        }

        [HttpGet("cars/model/{carModel}")]
        public ActionResult<IEnumerable<Orders>> GetOrdersByCarModel(string carModel)
        {
            var orderMethods = new OrderMethods(_context); 
            return orderMethods.GetOrderListByCarModel(carModel);
        }

        [HttpGet("cars/mark/{carMark}")]
        public ActionResult<IEnumerable<Orders>> GetOrdersByCarMark(string carMark)
        {
            var orderMethods = new OrderMethods(_context);
            return orderMethods.GetOrderListByCarMark(carMark);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Orders>> PutOrders(int id, Orders order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return order;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order ?? (ActionResult<Orders>) NotFound();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = orders.Id }, orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orders>> DeleteOrders(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
