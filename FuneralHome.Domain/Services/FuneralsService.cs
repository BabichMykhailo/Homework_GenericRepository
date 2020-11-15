using AutoMapper;
using FuneralHome.Data.Entities;
using FuneralHome.Data.Interfaces;
using FuneralHome.Data.Repositories;
using FuneralHome.Domain.Interfaces;
using FuneralHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Domain.Services
{
    public class FuneralsService : IFuneralService
    {
        private readonly IFuneralRepository _funeralRepository;
        private readonly IMapper _mapper;

        public FuneralsService()
        {
            _funeralRepository = new FuneralRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FuneralModel, Funeral>().ReverseMap();
                cfg.CreateMap<ClientModel, Client>().ReverseMap();
                cfg.CreateMap<EmployeeModel, Employee>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public FuneralModel Create(FuneralModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FuneralModel> GetAll()
        {
            var funerals = _funeralRepository.GetAll();

            return _mapper.Map<IEnumerable<FuneralModel>>(funerals);
        }
    }
}
