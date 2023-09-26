using AutoMapper;
using teahouse.Dtos.Tea;
using teahouse.Models;

namespace teahouse {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<Tea, GetTeaDto>();
            CreateMap<AddTeaDto, Tea>();
        }
    }
}