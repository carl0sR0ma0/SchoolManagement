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

            builder.HasKey(d => new { d.AlunoId, d.DisciplinaMatriculadaId });

            builder.HasOne(t => t.Aluno)
               .WithMany(a => a.Notas)
               .HasForeignKey(t => t.AlunoId)
               .HasPrincipalKey(t => t.Id)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.DisciplinaMatriculada)
               .WithMany(dm => dm.Notas)
               .HasForeignKey(t => t.DisciplinaMatriculadaId)
               .HasPrincipalKey(t => t.Id)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
