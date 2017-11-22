using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Models;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171122191301_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
