using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Cursos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(c => c.Coordenador)
                .HasMaxLength(80)
                .HasColumnType("VARCHAR");
        }
    }
}
