using AutoMapper;
using KanbanFlow.API.Helpers.Enums;
using KanbanFlow.API.Models.Domain;
using KanbanFlow.API.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Task = KanbanFlow.API.Models.Domain.Task;

namespace KanbanFlow.API.Helpers.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDto, IdentityUser>().ReverseMap();
            CreateMap<Task, TaskDto>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<TaskDto, Task>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => Enum.Parse<Priority>(src.Priority)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<TaskStatus>(src.Status)));

            CreateMap<CommentDto,Comment>().ReverseMap();
        }
    }
}
