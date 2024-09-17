using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTopDownDomain.Contracts.Interface;
using TesteTopDownDomain.Entities;

namespace TesteTopDownDomain.Contracts.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task   Adicionar(Tarefa tarefa)
        {
            //var user = _user.GetUserId();

            await _taskRepository.Adicionar(tarefa);
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            

            await _taskRepository.Atualizar(tarefa);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Remover(int id)
        {
            await _taskRepository.Remover(id);
        }

        
    }
}
