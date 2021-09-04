using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Mappings;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Data.ORM
{
    public class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options) : base(options) {}

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
        }
    }
}
