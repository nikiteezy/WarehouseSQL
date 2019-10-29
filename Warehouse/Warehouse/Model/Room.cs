
using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Model
{
    class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public int Temperature { get; set; }

        public List<RoomWorker> RoomWorkers { get; set; }

        public Room()
        {
            RoomWorkers = new List<RoomWorker>();
        }
    }
}
