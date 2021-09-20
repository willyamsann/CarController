using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CarUseRepository : GenericRepository<CarUse>, ICarUseRepository
    {
        public CarUseRepository(SqlContext context) : base(context)
        {
        }

        public IEnumerable<CarUse> GetAll()
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Driver)
                .Include(x => x.Car)
                .ToList();

            return obj;
        }

        public CarUse GetByDriverId(int id)
        {
            var obj = CurrentSet.AsNoTracking()
                 .Include(x => x.Driver)
                .Include(x => x.Car)
                .Where(x => x.DriverId == id)
                .FirstOrDefault();

            return obj;
        }

        public CarUse GetById(int id)
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Driver)
                .Include(x => x.Car)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return obj;
        }


    }
}
