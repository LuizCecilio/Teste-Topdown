using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTopDownDomain.Contracts.Interface;
using TesteTopDownDomain.Entities;
using TesteTopdownInfrastructure.Context;

namespace TesteTopdownInfrastructure.Repositories
{
    public  class TaskRepository : Repository<Tarefa>, ITaskRepository
    {
        public TaskRepository(MeuDbContext context) : base(context) { }

        public async Task<Tarefa> ObterTask(int id)
        {
            return await Db.Tarefas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        
    }
}
