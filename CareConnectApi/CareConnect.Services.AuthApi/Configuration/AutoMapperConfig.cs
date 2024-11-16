using AutoMapper;
using CareConnect.Services.AuthApi.models;
using CareConnect.Services.AuthApi.models.Dto;

namespace CareConnect.Services.AuthApi.Configurations
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDataDto>().ReverseMap();

        }
     
    }
}
