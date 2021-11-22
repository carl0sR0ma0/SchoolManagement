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
    public class PlanoDeEnsinoMap : IEntityTypeConfiguration<PlanoDeEnsino>
    {
        public void Configure(EntityTypeBuilder<PlanoDeEnsino> builder)
        {
            builder.ToTable("PlanoDeEnsino");

            builder.HasKey(pe => new { pe.TurmaId, pe.DisciplinaId });

            builder.HasOne(pe => pe.Turma)
                .WithMany(t => t.PlanoDeEnsino)
                .HasForeignKey(pe => pe.TurmaId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(pe => pe.Disciplina)
                .WithMany(d => d.Turmas)
                .HasForeignKey(pe => pe.DisciplinaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
