using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTopDownDomain.Entities;

namespace TesteTopDownDomain.Contracts.Interface
{
    public interface ITaskService : IDisposable
    {
        Task Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Remover(int id);
    }
}
