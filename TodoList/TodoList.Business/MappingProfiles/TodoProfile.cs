using AutoMapper;
using TodoList.Models;
using TodoList.Repositories.Entities;

namespace TodoList.Business.MappingProfiles;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        // Entity to Model
        CreateMap<Todo, TodoModel>()
            .ForMember(dest => dest.TodoId, opt => opt.MapFrom(src => src.TodoId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.ItemsCount, opt => opt.MapFrom(src => src.Items.Count()))
            ;

        // Model to Entity
        CreateMap<TodoModel, Todo>()
            .ForMember(dest => dest.TodoId, opt => opt.Ignore())
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            ;
    }
}