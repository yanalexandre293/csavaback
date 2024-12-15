﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ava.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241215230742_1")]
    partial class _1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Aula");
                });

            modelBuilder.Entity("AulaEstudante", b =>
                {
                    b.Property<int>("AulasAssistidasId")
                        .HasColumnType("integer");

                    b.Property<int>("EstudanteId")
                        .HasColumnType("integer");

                    b.HasKey("AulasAssistidasId", "EstudanteId");

                    b.HasIndex("EstudanteId");

                    b.ToTable("AulaEstudante");
                });

            modelBuilder.Entity("Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("DisciplinaEstudante", b =>
                {
                    b.Property<int>("DisciplinasCursadasId")
                        .HasColumnType("integer");

                    b.Property<int>("EstudanteId")
                        .HasColumnType("integer");

                    b.HasKey("DisciplinasCursadasId", "EstudanteId");

                    b.HasIndex("EstudanteId");

                    b.ToTable("DisciplinaEstudante");
                });

            modelBuilder.Entity("Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Estudante", b =>
                {
                    b.HasBaseType("Usuario");

                    b.ToTable("Estudante");
                });

            modelBuilder.Entity("Professor", b =>
                {
                    b.HasBaseType("Usuario");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Aula", b =>
                {
                    b.HasOne("Disciplina", "Disciplina")
                        .WithMany("Aulas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("AulaEstudante", b =>
                {
                    b.HasOne("Aula", null)
                        .WithMany()
                        .HasForeignKey("AulasAssistidasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Estudante", null)
                        .WithMany()
                        .HasForeignKey("EstudanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Disciplina", b =>
                {
                    b.HasOne("Professor", null)
                        .WithMany("DisciplinasLecionadas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DisciplinaEstudante", b =>
                {
                    b.HasOne("Disciplina", null)
                        .WithMany()
                        .HasForeignKey("DisciplinasCursadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Estudante", null)
                        .WithMany()
                        .HasForeignKey("EstudanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Estudante", b =>
                {
                    b.HasOne("Usuario", null)
                        .WithOne()
                        .HasForeignKey("Estudante", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Professor", b =>
                {
                    b.HasOne("Usuario", null)
                        .WithOne()
                        .HasForeignKey("Professor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Disciplina", b =>
                {
                    b.Navigation("Aulas");
                });

            modelBuilder.Entity("Professor", b =>
                {
                    b.Navigation("DisciplinasLecionadas");
                });
#pragma warning restore 612, 618
        }
    }
}
