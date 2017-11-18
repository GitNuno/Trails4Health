using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trails4Health.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trilhos",
                columns: table => new
                {
                    TrilhoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desativado_Trilho = table.Column<bool>(nullable: false),
                    Detalhes_Trilho = table.Column<string>(nullable: true),
                    Distancia_Trilho = table.Column<string>(nullable: true),
                    Fim_Trilho = table.Column<string>(nullable: true),
                    Foto_Trilho = table.Column<string>(nullable: true),
                    Inicio_Trilho = table.Column<string>(nullable: true),
                    Nome_Trilho = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhos", x => x.TrilhoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trilhos");
        }
    }
}
