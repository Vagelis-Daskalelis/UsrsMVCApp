using AutoMapper;
using UsrsMVCApp.DTO;
using UsrsMVCApp.Models;

namespace UsrsMVCApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserSignUpDTO>().ReverseMap();
        }
    }
}
