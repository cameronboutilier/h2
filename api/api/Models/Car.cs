using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string CarType { get; set; }
        public string CarColor { get; set; }
        public double CarCost { get; set; }
        public bool Convertible { get; set; }
    }
}
