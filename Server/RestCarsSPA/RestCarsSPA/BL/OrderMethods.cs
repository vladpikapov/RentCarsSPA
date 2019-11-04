using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public List<Orders> GetOrderListByCarModel(string model)
        {
            var cars = _context.Cars.Where(car => car.Model == model);
            var orders = new List<Orders>();
            foreach (var car in cars)
            {
                car.Orders = null;
                var currentCar = _context.Orders.Where(orderCar => orderCar.CarId == car.RegistrationNumber);
                orders.AddRange(currentCar);
                
            }

            return orders;
        }

        public List<Orders> GetOrderListByCarMark(string mark)
        {
            var cars = _context.Cars.Where(car => car.Mark == mark);
            var orders = new List<Orders>();
            foreach (var car in cars)
            {
                var currentCar = _context.Orders.Where(carNumber => carNumber.CarId == car.RegistrationNumber);
                orders.AddRange(currentCar);
            }

            return orders;
        }

        public List<Orders> GetOrderListByDriverName(string name)
        {
            var drivers = _context.Drivers.Where(driver => driver.FirstName == name);
            var orders = new List<Orders>();
            foreach (var driver in drivers)
            {
                var driverOrders =
                    _context.Orders.Where(license => license.DriverLicense == driver.NumberDriverLicense);
                orders.AddRange(driverOrders);
                
            }

            return orders;
        }
    }
}
