using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTopDownDomain.Entities;

namespace TesteTopDownDomain.Contracts.Interface
{
    public interface ITaskRepository : IRepository<Tarefa>
    {
        Task<Tarefa> ObterTask(int id);
    }
}
