using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace FuneralHome.Data.Repositories
{
    public class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : class, IEntity<TId>
    {
        protected DbContext _ctx;
        protected DbSet<T> _table;

        public GenericRepository()
        {
            _ctx = new FuneralHomeContext();
            _table = _ctx.Set<T>();
        }

        public void Create(T model)
        {
            _table.Add(model);

            _ctx.SaveChanges();
        }

        public void Delete(TId id)
        {
            var entity = _table.FirstOrDefault(x => x.Id.Equals(id));
            _table.Remove(entity);

            _ctx.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }


        public void Update(T model)
        {
            _table.AddOrUpdate(model);

            _ctx.SaveChanges();
        }

        public T GetById(TId id)
        {
            var item = _table.FirstOrDefault(x => x.Id.Equals(id));
            return item;
        }

        public IEnumerable<T> GetByDelegate(Expression<Func<T, bool>> del)
        {
            return _table.Where(del);
        }
    }
}

