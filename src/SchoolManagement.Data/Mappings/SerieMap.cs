using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class SerieMap : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.ToTable("Series");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(s => s.Nome)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR");

            builder.Property(s => s.Descricao)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR");

            builder.HasOne(s => s.Curso)
                .WithMany(s => s.Series)
                .HasForeignKey(s => s.CursoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
