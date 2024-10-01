using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteTopDown.Models;
using TesteTopDownDomain.Contracts.Interface;
using TesteTopDownDomain.Entities;

namespace TesteTopDown.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]

    public class TaskController : MainController
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IMapper mapper, 
                                ITaskRepository taskRepository, INotificador notificador): base(notificador)
        {
            _taskService = taskService;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        
        [HttpPost("Adicionar")]
        public async Task<IActionResult> AdicionarTarefa(AddTaskInput input)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _taskService.Adicionar(_mapper.Map<Tarefa>(input));

            return CustomResponse(input);
        }
        
        [HttpPut("Atualizar")]
        public async Task<IActionResult> UpdateTask(AddTaskInput input)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            await _taskService.Atualizar(_mapper.Map<Tarefa>(input));

            return CustomResponse(input);
        }

        [HttpDelete("Remover")]
        public async Task<ActionResult<AddTaskInput>> DeleteTask(int id)
        {
            var task = _mapper.Map<AddTaskInput>(await _taskRepository.ObterPorId(id));

            if (task == null) return NotFound();

            await  _taskService.Remover(id);

            return  CustomResponse(task);
        }

        [AllowAnonymous]
        [HttpGet("Consultar/Id")]
        public async Task<AddTaskInput> ObterTask(int id)
        {
            return _mapper.Map<AddTaskInput>(await _taskRepository.ObterPorId(id));            
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<AddTaskInput>> ObterTodos()
        {
            var fornecedor = _mapper.Map<IEnumerable<AddTaskInput>>(await _taskRepository.ObterTodos());
            return fornecedor;
        }

    }


}
