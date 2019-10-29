using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Model
{
    class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<RoomWorker> RoomWorkers { get; set; }

        public Worker()
        {
            RoomWorkers = new List<RoomWorker>();
        }
    }
}
