using FishingHunting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FishingHunting.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FishingHuntingContext FishingHuntingContext { get; set; }

        public RepositoryBase(FishingHuntingContext fishingHuntingContext)
        {
            this.FishingHuntingContext = fishingHuntingContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.FishingHuntingContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.FishingHuntingContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.FishingHuntingContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.FishingHuntingContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.FishingHuntingContext.Set<T>().Remove(entity);
        }


    }
}
