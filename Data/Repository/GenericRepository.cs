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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityGeneric
    {
        protected readonly SqlContext _sqlContext;
        protected readonly DbSet<TEntity> CurrentSet;

        public GenericRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
            CurrentSet = sqlContext.Set<TEntity>();
        }

        public void Insert(TEntity obj)
        {
            _sqlContext.Set<TEntity>().Add(obj);
            _sqlContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _sqlContext.Set<TEntity>().Remove(Select(id));
            _sqlContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _sqlContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _sqlContext.Set<TEntity>().Find(id);

    }

}
