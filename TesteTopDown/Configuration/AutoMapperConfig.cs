using AutoMapper;
using TesteTopDown.Models;
using TesteTopDownDomain.Entities;

namespace TesteTopDown.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddTaskInput, Tarefa>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)).
                ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).
                ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate)).
                ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
                ;
        }
    }
}
