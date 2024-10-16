﻿using AutoMapper;
using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using WebApiSchool.DTO.Accounts;
using WebApiSchool.DTO.Posts;
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

            CreateMap<PostUpdateDTO, Post>()
           .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            //  CreateMap<Post, PostDTO>()
            //.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Author.Username))
            //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd")));  // Format date

            CreateMap<PostCreateDTO, Post>()
            .ForMember(dest => dest.AuthorId, opt => opt.Ignore()) 
            .ForMember(dest => dest.Author, opt => opt.Ignore())  
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())); 
        }
    }
}
