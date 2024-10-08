﻿using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
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
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            builder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(builder);


            //TaskMapping(Configure);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }



    }
}
