using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trails4Health.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoResposta",
                columns: table => new
                {
                    TipoRespostaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoResposta", x => x.TipoRespostaID);
                });

            migrationBuilder.CreateTable(
                name: "QuestaoAvaliacaoGuia",
                columns: table => new
                {
                    TipoRespostaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desactivada = table.Column<bool>(nullable: false),
                    NomeQuestao = table.Column<string>(nullable: true),
                    QuestaoID = table.Column<int>(nullable: false),
                    TipoRespostaID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoAvaliacaoGuia", x => x.TipoRespostaID);
                    table.ForeignKey(
                        name: "FK_QuestaoAvaliacaoGuia_TipoResposta_TipoRespostaID1",
                        column: x => x.TipoRespostaID1,
                        principalTable: "TipoResposta",
                        principalColumn: "TipoRespostaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestaoAvaliacaoTrilho",
                columns: table => new
                {
                    TipoRespostaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desactivada = table.Column<bool>(nullable: false),
                    NomeQuestao = table.Column<string>(nullable: true),
                    QuestaoID = table.Column<int>(nullable: false),
                    TipoRespostaID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoAvaliacaoTrilho", x => x.TipoRespostaID);
                    table.ForeignKey(
                        name: "FK_QuestaoAvaliacaoTrilho_TipoResposta_TipoRespostaID1",
                        column: x => x.TipoRespostaID1,
                        principalTable: "TipoResposta",
                        principalColumn: "TipoRespostaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoAvaliacaoGuia_TipoRespostaID1",
                table: "QuestaoAvaliacaoGuia",
                column: "TipoRespostaID1");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoAvaliacaoTrilho_TipoRespostaID1",
                table: "QuestaoAvaliacaoTrilho",
                column: "TipoRespostaID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestaoAvaliacaoGuia");

            migrationBuilder.DropTable(
                name: "QuestaoAvaliacaoTrilho");

            migrationBuilder.DropTable(
                name: "TipoResposta");
        }
    }
}
