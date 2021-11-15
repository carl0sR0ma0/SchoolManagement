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
                .WithOne()
                .HasForeignKey<Matricula>(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(m => m.Turma)
                .WithOne() // WithMany
                .HasForeignKey<Matricula>(m => m.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(m => m.Disciplinas)
            //   .WithOne(dm => dm.Matricula)
            //   .HasForeignKey(dm => dm.MatriculaId)
            //   .HasPrincipalKey(m => m.Id)
            //   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
