using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Models;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171113231215_first migration")]
    partial class firstmigration
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

                    b.Property<bool>("Desativado_Trilho");

                    b.Property<string>("Detalhes_Trilho");

                    b.Property<string>("Distancia_Trilho");

                    b.Property<string>("Fim_Trilho");

                    b.Property<string>("Foto_Trilho");

                    b.Property<string>("Inicio_Trilho");

                    b.Property<string>("Nome_Trilho");

                    b.HasKey("TrilhoID");

                    b.ToTable("Trilhos");
                });
        }
    }
}
