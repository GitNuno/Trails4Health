using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trails4Health.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dificuldades",
                columns: table => new
                {
                    DificuldadeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificuldades", x => x.DificuldadeID);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoID);
                });

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
                name: "Trilhos",
                columns: table => new
                {
                    TrilhoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desativado = table.Column<bool>(nullable: false),
                    Detalhes = table.Column<string>(maxLength: 700, nullable: false),
                    DificuldadeID = table.Column<int>(nullable: false),
                    Distancia = table.Column<decimal>(nullable: false),
                    Fim = table.Column<string>(maxLength: 50, nullable: false),
                    Foto = table.Column<string>(nullable: false),
                    Inicio = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Sumario = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhos", x => x.TrilhoID);
                    table.ForeignKey(
                        name: "FK_Trilhos_Dificuldades_DificuldadeID",
                        column: x => x.DificuldadeID,
                        principalTable: "Dificuldades",
                        principalColumn: "DificuldadeID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "EstadoTrilhos",
                columns: table => new
                {
                    EstadoID = table.Column<int>(nullable: false),
                    TrilhoID = table.Column<int>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTrilhos", x => new { x.EstadoID, x.TrilhoID });
                    table.ForeignKey(
                        name: "FK_EstadoTrilhos_Estados_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estados",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadoTrilhos_Trilhos_TrilhoID",
                        column: x => x.TrilhoID,
                        principalTable: "Trilhos",
                        principalColumn: "TrilhoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadoTrilhos_TrilhoID",
                table: "EstadoTrilhos",
                column: "TrilhoID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoAvaliacaoGuia_TipoRespostaID1",
                table: "QuestaoAvaliacaoGuia",
                column: "TipoRespostaID1");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoAvaliacaoTrilho_TipoRespostaID1",
                table: "QuestaoAvaliacaoTrilho",
                column: "TipoRespostaID1");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhos_DificuldadeID",
                table: "Trilhos",
                column: "DificuldadeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadoTrilhos");

            migrationBuilder.DropTable(
                name: "QuestaoAvaliacaoGuia");

            migrationBuilder.DropTable(
                name: "QuestaoAvaliacaoTrilho");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Trilhos");

            migrationBuilder.DropTable(
                name: "TipoResposta");

            migrationBuilder.DropTable(
                name: "Dificuldades");
        }
    }
}
