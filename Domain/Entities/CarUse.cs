using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarUse : EntityGeneric
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string ReasonForUse { get; set; }

        public bool Finished { get; set; }
    }
}
