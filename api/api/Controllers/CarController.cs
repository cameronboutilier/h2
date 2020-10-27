using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly abcautomotiveContext _dataContext;
        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger, abcautomotiveContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<List<CarDTO>> Get(string date)
        {
            DateTime queryDate = DateTime.Now; 
            if (date != null)
                DateTime.TryParse(date, out queryDate);

            List<CarDTO> cars = new List<CarDTO>();
            _dataContext.Cars.ToList().ForEach(c => cars.Add(new CarDTO(c)));

            if (queryDate.Month == 5)
            {
                //Was a little confused here, so if the 20% brought the price down below cost i just lowered it to cost.
                cars.Where(c => c.Color == "Red").ToList().ForEach(x => x.Price = (x.Cost > (x.Price * 0.8) ? x.Cost : (x.Price * 0.8)));
                cars.Where(c => c.Convertible).ToList().ForEach(x => x.Price = (x.Price * 1.1));
            }
            if (queryDate.Month < 5 || queryDate.Month > 8)
                cars.Where(c => c.Type == "SUV").ToList().ForEach(x => x.Price = (x.Price * 1.1));

            return cars.OrderBy(x => x.Price).Reverse().ToList();
        }

        public class CarDTO
        {
            public CarDTO(Car c)
            {
                this.ID = c.Id;
                this.Color = c.CarColor;
                this.Type = c.CarType;
                this.Convertible = c.Convertible;
                this.Cost = c.CarCost;
                this.Price = c.CarCost * 1.15;
            }

            public int ID { get; set; }
            public string Color { get; set; }
            public string Type { get; set; }
            public double Profit 
            {    
                get { return Price - Cost; } 
            }
            public double Cost { get; set; }
            public double Price { get; set; }
            public bool Convertible { get; set; }
        }
    }
}