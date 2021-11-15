using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class NotasMap : IEntityTypeConfiguration<Notas>
    {
        public void Configure(EntityTypeBuilder<Notas> builder)
        {
            builder.ToTable("Notas");

            builder.HasKey(d => new { d.AlunoId });

            builder.HasOne(t => t.Aluno)
               .WithMany()
               .HasForeignKey(t => t.AlunoId)
               .HasPrincipalKey(t => t.Id)
               .OnDelete(DeleteBehavior.Cascade);
            
            //builder.HasOne(t => t.Disciplina)
            //   .WithMany()
            //   .HasForeignKey(t => t.DisciplinaId)
            //   .HasPrincipalKey(t => t.Id)
            //   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
