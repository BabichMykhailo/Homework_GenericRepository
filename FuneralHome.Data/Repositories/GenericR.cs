using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FuneralHome.Data.Repositories
{
    public class GenericR<T, TId> : IGenericRepository<T, TId> where T : class
    {
        protected FuneralHomeContext _ctx;
        protected DbSet<T> _table;
        public delegate bool MyDelegate(T entity);

        public GenericR()
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
            if(id.GetType() == DateTime.Now.GetType())
            {
                var date = id.GetType().GetProperty("Date");
                foreach (var e in _table)
                {
                    if(date.GetValue(id) == date.GetValue(e))
                    {
                        _table.Remove(e);
                        break;
                    }
                }
            }

            foreach (var e in _table)
            {
                var idProperty = e.GetType().GetProperty("Id");
                if (idProperty.GetValue(e).Equals(id))
                {
                    _table.Remove(e);
                    break;
                }
            }

            _ctx.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public IEnumerable<T> GetByDelegate()
        {
            throw new NotImplementedException();
        }

        public T GetById(TId id)
        {
            T entity = null;
            if (id.GetType() == DateTime.Now.GetType())
            {
                var date = id.GetType().GetProperty("Date");
                foreach (var e in _table)
                {
                    if (date.GetValue(id) == date.GetValue(e))
                    {
                        entity = e;
                        break;
                    }
                }
            }

            foreach (var e in _table)
            {
                var idProperty = e.GetType().GetProperty("Id");
                if (idProperty.GetValue(e).Equals(id))
                {
                    entity = e;
                    break;
                }
            }
            return entity;
        }

        public void Update(T model)
        {
            /*var id = (TId)model.GetType().GetProperty("Id").GetValue(model);
            var entity = _table.FirstOrDefault();*/
            _table.AddOrUpdate(model);

            _ctx.SaveChanges();
        }

        public IEnumerable<T> GetByDelegate(MyDelegate del)
        {
            var result = new List<T>();
            foreach(var entity in _table)
            {
                if (del(entity))
                {
                    result.Add(entity);
                }
            }
            return result;
        }
    }
}
