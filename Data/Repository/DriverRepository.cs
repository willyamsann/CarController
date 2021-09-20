using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(SqlContext context) : base(context)
        {
        }
        public IEnumerable<Driver> SearchByName(string name)
        {
            var obj = CurrentSet
                       .Where(x => x.Name.Contains(name)).ToList();

            return obj;
        }


    }
}
