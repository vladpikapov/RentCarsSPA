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

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{driverName}")]
        public ActionResult<IEnumerable<Orders>> GetOrdersByDriverName(string driverName)
        {
            var orderMethods = new OrderMethods(_context);
            return orderMethods.GetOrderListByDriverName(driverName).ToList();
        }


        [HttpGet("sorts/SortedByStartDate")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetSortedOrdersByStartDate()
        {
            return await _context.Orders.OrderByDescending(order => order.StartDate).ToListAsync();
        }


        [HttpGet("sorts/SortedByEndDate")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetSortedOrdersByEndDate()
        {
            return await _context.Orders.OrderByDescending(order => order.EndDate).ToListAsync();
        }

        [HttpGet("cars/model/{carModel}")]
        public ActionResult<IEnumerable<Orders>> GetOrdersByCarModel(string carModel)
        {
            var orderMethods = new OrderMethods(_context);
            var cars = orderMethods.GetOrderListByCarModel(carModel);
            return cars.ToList();
        }

        [HttpGet("cars/mark/{carMark}")]
        public ActionResult<IEnumerable<Orders>> GetOrdersByCarMark(string carMark)
        {
            var orderMethods = new OrderMethods(_context);
            var cars = orderMethods.GetOrderListByCarMark(carMark);
            return cars.ToList();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders orders)
        {
            if (id != orders.Id)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

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

            return RedirectToAction("GetOrders");
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
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return orders;
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
