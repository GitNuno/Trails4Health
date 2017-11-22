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

            modelBuilder.Entity("Trails4Health.Models.Trilho", b =>
                {
                    b.Property<int>("TrilhoID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Desativado");

                    b.Property<string>("Detalhes");

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

                    b.ToTable("Trilhos");
                });
        }
    }
}
