using System;
using System.Linq;
using AutoMapper;
using ProjectExample.Context.Entities;
using ProjectExample.Domain;
using ProjectExample.Domain.Enum;

namespace ProjectExample.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeEntity, EmployeeDomain>().ReverseMap();

            CreateMap<HrEntity, HrDomain>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(
                    src => StringToEnum(src.Type)));

            CreateMap<HrDomain, HrEntity>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(
                    src => src.Type.ToString()));
        }
        

        private HrSpecializzation StringToEnum(string stringifiedType)
        {
            var result = Enum.GetNames(typeof(HrSpecializzation)).ToList();

            if (!result.Contains(stringifiedType))
            {
                throw new ArgumentException("Could not convert this argument string to an EventTypeEnum.");
            }

            return (HrSpecializzation)result.IndexOf(stringifiedType);
        }
    }
}