using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Model
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public History History { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
