using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turmas");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.HasOne(t => t.Serie)
                .WithMany()
                .HasForeignKey(t => t.SerieId)
                .HasPrincipalKey(t => t.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
