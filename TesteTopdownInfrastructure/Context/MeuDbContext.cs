using Microsoft.EntityFrameworkCore;
using TesteTopDownDomain.Entities;
using TesteTopdownInfrastructure.Mappings;

namespace TesteTopdownInfrastructure.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);
            //TaskMapping(Configure);
            
        }



    }
}
