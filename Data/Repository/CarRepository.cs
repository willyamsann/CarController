using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(SqlContext context) : base(context)
        {
        }

        public IEnumerable<Car> SearchByFilter(string color, string brand)
        {
            var obj = CurrentSet
                       .Where(x => x.Color.Contains(color) || x.Brand.Contains(brand)).ToList();

            return obj;
        }


    }
}
