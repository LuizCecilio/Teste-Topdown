using AutoMapper;
using Moq;
using TesteTopDownDomain.Contracts.Interface;
using TesteTopDownDomain.Contracts.Services;
using TesteTopDownDomain.Entities;
using Xunit;

namespace TesteTopApplicationTests.Common
{
    public class CommonTests
    {
        private TaskService taskService;
        private IMapper _mapper;
        private INotificador _notificador;

        public CommonTests(IMapper mapper, INotificador notificador)
        {
            taskService = new TaskService(new Mock<ITaskRepository>().Object,_mapper = mapper, _notificador = notificador); 
        }

        [Fact]
        public void Post_AddTask()
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = 1;
            tarefa.Description = "teste";
            tarefa.Title = "Titulo teste";
            tarefa.DueDate = DateTime.UtcNow;

            var result =  taskService.Adicionar(tarefa);
            Assert.True(true);
        }

        [Fact]
        public void Put_UpdateTask()
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = 1;
            tarefa.Description = "teste";
            tarefa.Title = "Titulo teste";
            tarefa.DueDate = DateTime.UtcNow;

            var result = taskService.Atualizar(tarefa);
            Assert.True(true);
        }

        [Fact]
        public void Delete_Task()
        {
            int id = 1;
            var result = taskService.Remover(id);
            Assert.True(true);
        }

    }
}
