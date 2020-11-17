using AutoMapper;
using FuneralHome.Domain.Interfaces;
using FuneralHome.Domain.Models;
using FuneralHome.Domain.Services;
using FuneralHome.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Controllers
{
    public class FuneralsController
    {
        private readonly IFuneralService _funeralService;
        private readonly IMapper _mapper;

        public FuneralsController()
        {
            _funeralService = new FuneralsService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FuneralModel, FuneralViewModel>().ReverseMap();
                cfg.CreateMap<ClientModel, ClientViewModel>().ReverseMap();
                cfg.CreateMap<EmployeeModel, EmployeeViewModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public IEnumerable<FuneralViewModel> GetAll()
        {
            var funerals = _funeralService.GetAll();

            return _mapper.Map<IEnumerable<FuneralViewModel>>(funerals);
        }
    }
}
