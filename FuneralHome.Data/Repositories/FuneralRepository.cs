using FuneralHome.Data.Entities;
using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Repositories
{
    public class FuneralRepository : IFuneralRepository
    {
        private readonly FuneralHomeContext _ctx;

        public FuneralRepository()
        {
            _ctx = new FuneralHomeContext();
        }

        public IEnumerable<Funeral> GetAll()
        {
            return _ctx.Funerals
                .Include(x => x.Client)
                .Include(x => x.Employees)
                .AsNoTracking()
                .ToList();
        }

        public Funeral Create(Funeral model)
        {
            _ctx.Funerals.Add(model);
            _ctx.SaveChanges();

            return model;
        }
    }
}
