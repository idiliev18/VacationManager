using api.Controllers;
using api.Data.Models;
using api.Dto.Projects;
using api.Dto.Team;
using api.Dto.User;
using AutoMapper;
using System.Diagnostics.Metrics;

namespace api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
 
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();

            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();

            CreateMap<Project, CreateProjectDto>().ReverseMap();
        }
    }
}
