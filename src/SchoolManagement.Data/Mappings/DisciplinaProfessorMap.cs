using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class DisciplinaProfessorMap : IEntityTypeConfiguration<DisciplinaProfessor>
    {
        public void Configure(EntityTypeBuilder<DisciplinaProfessor> builder)
        {
            builder.ToTable("DisciplinaProfessor");

            builder.HasKey(d => d.Id);

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
