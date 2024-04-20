using AutoMapper;
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
        }
    }
}
