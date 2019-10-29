using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Model
{
    class RoomWorker
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}
