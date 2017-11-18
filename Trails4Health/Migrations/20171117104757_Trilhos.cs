using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trails4Health.Migrations
{
    public partial class Trilhos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalhes_Trilho",
                table: "Trilhos");

            migrationBuilder.RenameColumn(
                name: "Nome_Trilho",
                table: "Trilhos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Inicio_Trilho",
                table: "Trilhos",
                newName: "Inicio");

            migrationBuilder.RenameColumn(
                name: "Foto_Trilho",
                table: "Trilhos",
                newName: "Foto");

            migrationBuilder.RenameColumn(
                name: "Fim_Trilho",
                table: "Trilhos",
                newName: "Fim");

            migrationBuilder.RenameColumn(
                name: "Distancia_Trilho",
                table: "Trilhos",
                newName: "Detalhes");

            migrationBuilder.RenameColumn(
                name: "Desativado_Trilho",
                table: "Trilhos",
                newName: "Desativado");

            migrationBuilder.AddColumn<decimal>(
                name: "Distancia",
                table: "Trilhos",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distancia",
                table: "Trilhos");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Trilhos",
                newName: "Nome_Trilho");

            migrationBuilder.RenameColumn(
                name: "Inicio",
                table: "Trilhos",
                newName: "Inicio_Trilho");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Trilhos",
                newName: "Foto_Trilho");

            migrationBuilder.RenameColumn(
                name: "Fim",
                table: "Trilhos",
                newName: "Fim_Trilho");

            migrationBuilder.RenameColumn(
                name: "Detalhes",
                table: "Trilhos",
                newName: "Distancia_Trilho");

            migrationBuilder.RenameColumn(
                name: "Desativado",
                table: "Trilhos",
                newName: "Desativado_Trilho");

            migrationBuilder.AddColumn<string>(
                name: "Detalhes_Trilho",
                table: "Trilhos",
                nullable: true);
        }
    }
}
