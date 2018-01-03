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
                name: "TipoQuestoes",
                columns: table => new
                {
                    TipoQuestaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuestoes", x => x.TipoQuestaoID);
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
                name: "Questoes",
                columns: table => new
                {
                    QuestaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desactivada = table.Column<string>(nullable: true),
                    NomeQuestao = table.Column<string>(nullable: true),
                    NumeroOpcoes = table.Column<int>(nullable: false),
                    TipoQuestaoID = table.Column<int>(nullable: false),
                    TipoResposta = table.Column<string>(nullable: true),
                    ValorMaximo = table.Column<int>(nullable: false),
                    ValorMinimo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.QuestaoID);
                    table.ForeignKey(
                        name: "FK_Questoes_TipoQuestoes_TipoQuestaoID",
                        column: x => x.TipoQuestaoID,
                        principalTable: "TipoQuestoes",
                        principalColumn: "TipoQuestaoID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_EstadoTrilhos_TrilhoID",
                table: "EstadoTrilhos",
                column: "TrilhoID");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_TipoQuestaoID",
                table: "Questoes",
                column: "TipoQuestaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_QuestaoID",
                table: "Resposta",
                column: "QuestaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_TuristaID",
                table: "Resposta",
                column: "TuristaID");

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
                name: "Guia");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Trilhos");

            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "Turista");

            migrationBuilder.DropTable(
                name: "Dificuldades");

            migrationBuilder.DropTable(
                name: "TipoQuestoes");
        }
    }
}
