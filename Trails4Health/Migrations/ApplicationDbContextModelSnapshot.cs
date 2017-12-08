using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Models;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trails4Health.Models.Dificuldade", b =>
                {
                    b.Property<int>("DificuldadeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Observacao");

                    b.HasKey("DificuldadeID");

                    b.ToTable("Dificuldades");
                });

            modelBuilder.Entity("Trails4Health.Models.Estado", b =>
                {
                    b.Property<int>("EstadoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("EstadoID");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Trails4Health.Models.EstadoTrilho", b =>
                {
                    b.Property<int>("EstadoID");

                    b.Property<int>("TrilhoID");

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.HasKey("EstadoID", "TrilhoID");

                    b.HasIndex("TrilhoID");

                    b.ToTable("EstadoTrilhos");
                });

            modelBuilder.Entity("Trails4Health.Models.Trilho", b =>
                {
                    b.Property<int>("TrilhoID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Desativado");

                    b.Property<string>("Detalhes")
                        .IsRequired();

                    b.Property<int>("DificuldadeID");

                    b.Property<decimal>("Distancia");

                    b.Property<string>("Fim")
                        .IsRequired();

                    b.Property<string>("Foto")
                        .IsRequired();

                    b.Property<string>("Inicio")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("TrilhoID");

                    b.HasIndex("DificuldadeID");

                    b.ToTable("Trilhos");
                });

            modelBuilder.Entity("Trails4Health.Models.EstadoTrilho", b =>
                {
                    b.HasOne("Trails4Health.Models.Estado", "Estado")
                        .WithMany("EstadoTrilhos")
                        .HasForeignKey("EstadoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Trilho", "Trilho")
                        .WithMany("EstadoTrilhos")
                        .HasForeignKey("TrilhoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.Trilho", b =>
                {
                    b.HasOne("Trails4Health.Models.Dificuldade", "Dificuldade")
                        .WithMany("Trilhos")
                        .HasForeignKey("DificuldadeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
