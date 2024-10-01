using AutoMapper;
using TesteTopDown.Models;
using TesteTopDownDomain.Entities;

namespace TesteTopDown.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddTaskInput, Tarefa>().ReverseMap();
        }
    }
}
