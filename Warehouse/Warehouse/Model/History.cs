using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Warehouse.Model
{
    class History
    {
        public int Id { get; set; }
        public DateTime Come { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
