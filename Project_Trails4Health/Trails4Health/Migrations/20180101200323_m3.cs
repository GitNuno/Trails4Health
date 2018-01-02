using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trails4Health.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desactivada",
                table: "Questoes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Guia",
                columns: table => new
                {
                    GuiaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guia", x => x.GuiaID);
                });

            migrationBuilder.CreateTable(
                name: "Turista",
                columns: table => new
                {
                    TuristaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Idade = table.Column<int>(nullable: false),
                    Morada = table.Column<string>(nullable: true),
                    Nif = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turista", x => x.TuristaID);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    RespostaQuestionarioID = table.Column<int>(nullable: false),
                    QuestaoID = table.Column<int>(nullable: false),
                    TuristaID = table.Column<int>(nullable: false),
                    Resposta_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => new { x.RespostaQuestionarioID, x.QuestaoID, x.TuristaID });
                    table.ForeignKey(
                        name: "FK_Resposta_Questoes_QuestaoID",
                        column: x => x.QuestaoID,
                        principalTable: "Questoes",
                        principalColumn: "QuestaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resposta_Turista_TuristaID",
                        column: x => x.TuristaID,
                        principalTable: "Turista",
                        principalColumn: "TuristaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_QuestaoID",
                table: "Resposta",
                column: "QuestaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_TuristaID",
                table: "Resposta",
                column: "TuristaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guia");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Turista");

            migrationBuilder.DropColumn(
                name: "Desactivada",
                table: "Questoes");
        }
    }
}
