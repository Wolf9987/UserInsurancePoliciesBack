using AutoMapper;
using UsersInsurancePolicies.Models;
using UsersInsurancePolicies.Models.Dto;

namespace UsersInsurancePolicies
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UsersDto, Users>().ReverseMap();
                config.CreateMap<InsurancePoliciesDto, InsurancePolicies>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
