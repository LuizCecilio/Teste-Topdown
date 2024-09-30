using AutoMapper;
using TesteTopDownDomain.Contracts.Interface;
using TesteTopDownDomain.Entities;

namespace TesteTopDownDomain.Contracts.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<bool> Adicionar(Tarefa tarefa)
        {
            if (_taskRepository.Buscar(f => f.Id == tarefa.Id).Result.Any())
            {
                //Notificar("Já existe um fornecedor com este documento informado.");
                return false;
            }

            await _taskRepository.Adicionar(tarefa);
            return true;
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            

            await _taskRepository.Atualizar(tarefa);
        }
        

        public async Task Remover(int id)
        {
            await _taskRepository.Remover(id);
        }

        public async Task<Tarefa> Obter(int id)
        {
            return _mapper.Map<Tarefa>(_taskRepository.ObterPorId(id));            
        }

        
    }
}
