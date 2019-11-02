using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestCarsSPA.BL
{
    public class OrderMethods
    {
        private readonly RestCarsDBContext _context;

        public OrderMethods(RestCarsDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Orders> GetOrderListByCarModel(string model)
        {
            var cars = _context.Cars.Where(car => car.Model == model);
            var orders = new List<Orders>();
            foreach (var car in cars)
            {
                orders.Add(_context.Orders.FirstOrDefault(orderCar => orderCar.CarId == car.RegistrationNumber));
            }

            return orders;
        }

        public IEnumerable<Orders> GetOrderListByCarMark(string mark)
        {
            var cars = _context.Cars.Where(car => car.Mark == mark);
            var orders = new List<Orders>();
            foreach (var car in cars)
            {
                orders.Add(_context.Orders.FirstOrDefault(orderCar => orderCar.CarId == car.RegistrationNumber));
            }

            return orders;
        }

        public IEnumerable<Orders> GetOrderListByDriverName(string name)
        {
            var drivers = _context.Drivers.Where(driver => driver.FirstName == name);
            var orders = new List<Orders>();
            foreach (var driver in drivers)
            {
                orders.Add(_context.Orders.FirstOrDefault(orderDriver=>orderDriver.DriverLicense == driver.NumberDriverLicense));
            }

            return orders;
        }
    }
}
