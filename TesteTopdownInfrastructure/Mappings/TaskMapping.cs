using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteTopDownDomain.Entities;

namespace TesteTopdownInfrastructure.Mappings
{
    public class TaskMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(200);

            builder.Property(p => p.Title)
                .HasMaxLength(50);

            // 1 : 1 => Fornecedor : Endereco
            builder.Property(p => p.DueDate)
                .HasColumnType("datetime");

            // 1 : N => Fornecedor : Produtos
            builder.Property(p => p.IsCompleted)
                .HasColumnType("bit");
            
        }
    }
}
