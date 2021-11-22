using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matriculas");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.HasOne(m => m.Aluno)
                .WithMany()
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Turma)
                .WithMany()
                .HasPrincipalKey(t => t.Id)
                .HasForeignKey(m => m.TurmaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
