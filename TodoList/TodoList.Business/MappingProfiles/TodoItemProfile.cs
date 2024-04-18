using AutoMapper;
using TodoList.Models;
using TodoList.Repositories.Entities;

namespace TodoList.Business.MappingProfiles;

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        // Entity to Model
        CreateMap<TodoItem, TodoItemModel>()
            .ForMember(dest => dest.TodoItemId, opt => opt.MapFrom(src => src.TodoItemId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
            .ForMember(dest => dest.IsDone, opt => opt.MapFrom(src => src.IsDone))
            ;

        // Model to Entity
        CreateMap<TodoItemModel, TodoItem>()
            .ForMember(dest => dest.TodoItemId, opt => opt.Ignore())
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
            .ForMember(dest => dest.IsDone, opt => opt.MapFrom(src => src.IsDone))
            ;
    }
}