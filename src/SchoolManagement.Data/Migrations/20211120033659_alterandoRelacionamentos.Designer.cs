﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagement.Data.ORM;

namespace SchoolManagement.Data.Migrations
{
    [DbContext(typeof(SchoolManagementContext))]
    [Migration("20211120033659_alterandoRelacionamentos")]
    partial class alterandoRelacionamentos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolManagement.Domain.Models.Aluno", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RA")
                        .HasColumnType("bigint");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Colaborador", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CPTS")
                        .HasColumnType("bigint");

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Formacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Curso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Coordenador")
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerieFin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerieIni")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Disciplina", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AulasSemanais")
                        .HasColumnType("int");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("ConteudoProgramatico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ementa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaltasPermitidas")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.DisciplinaMatriculada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DisicplinaId")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Horario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MatriculaId")
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.HasIndex("DisicplinaId");

                    b.HasIndex("MatriculaId");

                    b.ToTable("DisciplinaMatriculada");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.DisciplinaProfessor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("DisciplinaId")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Horario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProfessorId")
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("DisciplinaProfessor");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Matricula", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AlunoId")
                        .HasColumnType("BIGINT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TurmaId")
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Nota", b =>
                {
                    b.Property<long>("AlunoId")
                        .HasColumnType("BIGINT");

                    b.Property<long>("TurmaId")
                        .HasColumnType("BIGINT");

                    b.Property<long>("DisciplinaId")
                        .HasColumnType("BIGINT");

                    b.Property<bool?>("AprovadoReprovado")
                        .HasColumnType("bit");

                    b.Property<double?>("Media")
                        .HasColumnType("float");

                    b.Property<double?>("Nota1")
                        .HasColumnType("float");

                    b.Property<double?>("Nota2")
                        .HasColumnType("float");

                    b.Property<double?>("Nota3")
                        .HasColumnType("float");

                    b.Property<double?>("Nota4")
                        .HasColumnType("float");

                    b.HasKey("AlunoId", "TurmaId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.PlanoDeEnsino", b =>
                {
                    b.Property<long>("TurmaId")
                        .HasColumnType("BIGINT");

                    b.Property<long>("DisciplinaId")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Dia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdAulas")
                        .HasColumnType("int");

                    b.HasKey("TurmaId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("PlanoDeEnsino");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Professor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CPTS")
                        .HasColumnType("bigint");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Formacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Licenca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Responsavel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AlunoId")
                        .HasColumnType("BIGINT");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Responsavel");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Serie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CursoId")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Turma", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SerieId")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.DisciplinaMatriculada", b =>
                {
                    b.HasOne("SchoolManagement.Domain.Models.Disciplina", "Disciplina")
                        .WithMany("DisciplinaMatriculadas")
                        .HasForeignKey("DisicplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagement.Domain.Models.Matricula", "Matricula")
                        .WithMany("DisciplinaMatriculadas")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.DisciplinaProfessor", b =>
                {
                    b.HasOne("SchoolManagement.Domain.Models.Disciplina", "Disciplina")
                        .WithMany("Professores")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagement.Domain.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Matricula", b =>
                {
                    b.HasOne("SchoolManagement.Domain.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagement.Domain.Models.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Nota", b =>
                {
                    b.HasOne("SchoolManagement.Domain.Models.Aluno", "Aluno")
                        .WithMany("Notas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagement.Domain.Models.Disciplina", "Disciplina")
                        .WithMany("Notas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagement.Domain.Models.Turma", "Turma")
                        .WithMany("Notas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.PlanoDeEnsino", b =>
                {
                    b.HasOne("SchoolManagement.Domain.Models.Disciplina", "Disciplina")
                        .WithMany("Turmas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagement.Domain.Models.Turma", "Turma")
                        .WithMany("PlanoDeEnsino")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Responsavel", b =>
                {
                    b.HasOne("SchoolManagement.Domain.Models.Aluno", null)
                        .WithMany("Responsavel")
                        .HasForeignKey("AlunoId");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Serie", b =>
                {
                    b.HasOne("SchoolManagement.Domain.Models.Curso", "Curso")
                        .WithMany("Series")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Turma", b =>
                {
                    b.HasOne("SchoolManagement.Domain.Models.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Aluno", b =>
                {
                    b.Navigation("Notas");

                    b.Navigation("Responsavel");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Curso", b =>
                {
                    b.Navigation("Series");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Disciplina", b =>
                {
                    b.Navigation("DisciplinaMatriculadas");

                    b.Navigation("Notas");

                    b.Navigation("Professores");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Matricula", b =>
                {
                    b.Navigation("DisciplinaMatriculadas");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Professor", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("SchoolManagement.Domain.Models.Turma", b =>
                {
                    b.Navigation("Notas");

                    b.Navigation("PlanoDeEnsino");
                });
#pragma warning restore 612, 618
        }
    }
}
