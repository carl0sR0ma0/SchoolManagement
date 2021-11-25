using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class NotasMap : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable("Notas");

            builder.HasKey(n => new { n.AlunoId, n.TurmaId, n.DisciplinaId });

            builder.HasOne(n => n.Aluno)
               .WithMany(a => a.Notas)
               .HasForeignKey(n => n.AlunoId)
               .HasPrincipalKey(a => a.Id)
               .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(n => n.Turma)
               .WithMany(t => t.Notas)
               .HasForeignKey(n => n.TurmaId)
               .HasPrincipalKey(t => t.Id)
               .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(n => n.Disciplina)
               .WithMany(d => d.Notas)
               .HasForeignKey(n => n.DisciplinaId)
               .HasPrincipalKey(d => d.Id)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
