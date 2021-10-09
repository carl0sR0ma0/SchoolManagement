using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("Disciplinas");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");
        }
    }
}
