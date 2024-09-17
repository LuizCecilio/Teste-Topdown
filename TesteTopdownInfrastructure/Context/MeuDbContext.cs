using Microsoft.EntityFrameworkCore;
using TesteTopDownDomain.Entities;

namespace TesteTopdownInfrastructure.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString : "Data Source= Banco.sqlite");

            base.OnConfiguring(optionsBuilder);


        }



    }
}
