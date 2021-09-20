using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : EntityGeneric
    {
        public string License { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }

    }
}
