using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.Mappings
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaboradores");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");
        }
    }
}
