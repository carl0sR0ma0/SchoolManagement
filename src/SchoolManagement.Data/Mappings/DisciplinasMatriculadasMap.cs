using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class DisciplinasMatriculadasMap : IEntityTypeConfiguration<DisciplinasMatriculadas>
    {
        public void Configure(EntityTypeBuilder<DisciplinasMatriculadas> builder)
        {
            builder.ToTable("Disciplinas Matriculadas");

            builder.HasKey(d => new { d.Id, d.ProfessorId, d.DisciplinaId });

            builder.Property(d => d.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.HasOne(s => s.Professor)
                .WithMany(s => s.Disciplinas)
                .HasForeignKey(s => s.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Disciplina)
               .WithMany(s => s.Professores)
               .HasForeignKey(s => s.DisciplinaId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
