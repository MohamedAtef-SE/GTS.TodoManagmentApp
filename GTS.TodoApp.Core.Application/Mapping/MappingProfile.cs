using AutoMapper;
using GTS.TodoApp.Core.Domain.Entities;
using GTS.TodoApp.Shared.DTOs;

namespace GTS.TodoApp.Core.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Todo, TodoDTO>()
            .ForMember(todo => todo.Id,option => option.MapFrom(todoDTO => todoDTO.Id.ToString()))
            .ReverseMap();
        }
    }
}
