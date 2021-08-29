using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.ORM
{
    public class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options) : base(options) {}

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
