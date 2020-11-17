using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Interfaces
{
    public interface IGenericRepository<T, TId> where T : class 
    { 
        IEnumerable<T> GetAll();
        T GetById(TId id);
        void Create(T model);
        void Update(T model);
        void Delete(TId id);
        IEnumerable<T> GetByDelegate(Expression<Func<T, bool>> del);
    }
}
