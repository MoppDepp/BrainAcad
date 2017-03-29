namespace CarShop.Services.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using CarShop.Contracts;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext context;

        private readonly DbSet<T> set; 

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.set = this.context.Set<T>();
        }

        public void Add(T model)
        {
            this.set.Add(model);
        }

        public void AddRange(IEnumerable<T> models)
        {
            this.set.AddRange(models);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedProperties)
        {
            IQueryable<T> query = this.set.Where(predicate);
            if (includedProperties == null)
            {
                return query.ToList();
            }

            foreach (var includedProperty in includedProperties)
            {
                query.Include(includedProperty);
            }

            return query.ToList();
        }

        public T Get(object id)
        {
            return this.set.Find(id);
        }

        public void Remove(object id)
        {
            var entity = this.Get(id);
            if (this.context.Entry(entity).State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            this.set.Remove(entity);
        }

        public void Update(T model)
        {
            this.set.Attach(model);
            this.context.Entry(model).State = EntityState.Modified;
        }
    }
}