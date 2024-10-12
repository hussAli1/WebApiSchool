using AutoMapper;
using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiSchool.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<LoginDTO,User>().ReverseMap();
            CreateMap<CourseDTO, Course>().ReverseMap();

            CreateMap<RegisterDTO, User>()
            .ForMember(dest => dest.GUID, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<Post, PostDTO>()
           .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Author.Username)); 
        }
    }
}
