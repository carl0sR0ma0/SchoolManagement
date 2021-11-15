using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Mappings
{
    public class DisciplinaMatriculadaMap : IEntityTypeConfiguration<DisciplinaMatriculada>
    {
        public void Configure(EntityTypeBuilder<DisciplinaMatriculada> builder)
        {
            builder.ToTable("DisciplinaMatriculada");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.HasOne(s => s.DisciplinaProfessor)
                .WithMany(s => s.DisciplinaMatriculadas)
                .HasForeignKey(s => s.DisicplinaProfessorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Matricula)
               .WithMany(s => s.DisciplinaMatriculadas)
               .HasForeignKey(s => s.MatriculaId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
