namespace CarShop.Tests.Fake
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class FakeDbSet<T> : DbSet<T>, IQueryable
        where T : class
    {
        private readonly List<T> innerSet = new List<T>();

        public override T Add(T entity)
        {
            this.innerSet.Add(entity);
            return entity;
        }

        public IEnumerator GetEnumerator()
        {
            return this.innerSet.GetEnumerator();
        }

        public Expression Expression
        {
            get
            {
                return this.innerSet.AsQueryable().Expression;
            }
        }

        public Type ElementType
        {
            get
            {
                return this.innerSet.AsQueryable().ElementType;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return this.innerSet.AsQueryable().Provider;
            }
        }
    }
}
