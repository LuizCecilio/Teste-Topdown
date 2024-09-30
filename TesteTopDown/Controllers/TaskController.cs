﻿using AutoMapper;
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

    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IMapper mapper, ITaskRepository taskRepository)
        {
            _taskService = taskService;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        
        [HttpPost("Adicionar")]
        public async Task<IActionResult> AdicionarTarefa(AddTaskInput input)
        {          

            await _taskService.Adicionar(_mapper.Map<Tarefa>(input));

            return Created("Tarefa criada com sucesso.", input);
        }

        [HttpPut("Atualizar")]
        public IActionResult UpdateTask(AddTaskInput input)
        {
            _taskService.Atualizar(_mapper.Map<Tarefa>(input));
            return Ok("Tarefa Atualizada com sucesso.");
        }

        [HttpDelete("Remover")]
        public IActionResult DeleteTask(int id)
        {
            _taskService.Remover(id);
            return Ok("Tarefa Excluida com sucesso.");
        }

        [AllowAnonymous]
        [HttpGet("Consultar/{id:int}")]
        public async Task<Tarefa> ObterTask(int id)
        {
            return _mapper.Map<Tarefa>(_taskRepository.ObterPorId(id));            
        }


    }


}
