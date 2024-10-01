using AutoMapper;
using TesteTopDownDomain.Contracts.Interface;
using TesteTopDownDomain.Entities;

namespace TesteTopDownDomain.Contracts.Services
{
    public class TaskService : BaseService,ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<bool> Adicionar(Tarefa tarefa)
        {
            var task = _mapper.Map<Tarefa>(await _taskRepository.ObterPorId(tarefa.Id));

            if (task != null)
            {
                Notificar("Já existe uma tarefa com este id informado.");
                return false;
            }

            await _taskRepository.Adicionar(tarefa);
            return true;
        }

        public async Task<bool> Atualizar(Tarefa tarefa)
        {
            var task = _mapper.Map<Tarefa>(await _taskRepository.ObterPorId(tarefa.Id));

            if (task == null)
            {
                Notificar("Não existe a tarefa informada.");
                return false;
            }         

            await _taskRepository.Atualizar(tarefa);
            return true;
        }
        

        public async Task<bool> Remover(int id)
        {
            var task = _mapper.Map<Tarefa>(await _taskRepository.ObterPorId(id));

            if (task == null)
            {
                Notificar("Não existe a tarefa infortmada.");
                return false;
            }
            await _taskRepository.Remover(id);
            return true;
        }       

        
    }
}
