using AutoMapper;
using KanbanFlow.API.Helpers.Enums;
using KanbanFlow.API.Models.Domain;
using KanbanFlow.API.Models.DTOs;
using KanbanFlow.API.Models.DTOs.Comment;
using KanbanFlow.API.Models.DTOs.Task;
using Microsoft.AspNetCore.Identity;
using Task = KanbanFlow.API.Models.Domain.Task;

namespace KanbanFlow.API.Helpers.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDto, IdentityUser>().ReverseMap();

            CreateMap<Task, TaskDto>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<TaskDto, Task>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => Enum.Parse<Priority>(src.Priority)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<Status>(src.Status)));
            CreateMap<Task, TaskAddDto>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<TaskAddDto, Task>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => Enum.Parse<Priority>(src.Priority)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<Status>(src.Status)));
            CreateMap<Task, TaskEditDto>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<TaskEditDto, Task>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => Enum.Parse<Priority>(src.Priority)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<Status>(src.Status)));

            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CommentUpdateDto>().ReverseMap();
            CreateMap<Comment, CommentAddDto>().ReverseMap();
        }
    }
}
