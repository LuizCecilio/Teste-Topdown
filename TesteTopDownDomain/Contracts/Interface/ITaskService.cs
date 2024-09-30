using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTopDownDomain.Entities;

namespace TesteTopDownDomain.Contracts.Interface
{
    public interface ITaskService
    {
        Task<bool> Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Remover(int id);
        Task<Tarefa> Obter(int id);
    }
}
