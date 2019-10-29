using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Model
{
    class ProductType
    {
        public int Id { get; set; }
        public string MinTemperature { get; set; }
        public string MaxTemperature { get; set; }
        public int Humidity { get; set; }

        public List<Product> Products { get; set; }
    }
}
