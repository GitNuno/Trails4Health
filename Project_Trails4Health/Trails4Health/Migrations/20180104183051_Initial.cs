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
                name: "Guias",
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
                    table.PrimaryKey("PK_Guias", x => x.GuiaID);
                });

            migrationBuilder.CreateTable(
                name: "Questionarios",
                columns: table => new
                {
                    QuestionarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataRespostas = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionarios", x => x.QuestionarioID);
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
                name: "Turistas",
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
                    table.PrimaryKey("PK_Turistas", x => x.TuristaID);
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
                name: "RespostaQuestionarios",
                columns: table => new
                {
                    RespostaQuestionarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    QuestionarioID = table.Column<int>(nullable: false),
                    TuristaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaQuestionarios", x => x.RespostaQuestionarioID);
                    table.ForeignKey(
                        name: "FK_RespostaQuestionarios_Questionarios_QuestionarioID",
                        column: x => x.QuestionarioID,
                        principalTable: "Questionarios",
                        principalColumn: "QuestionarioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostaQuestionarios_Turistas_TuristaID",
                        column: x => x.TuristaID,
                        principalTable: "Turistas",
                        principalColumn: "TuristaID",
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
                name: "QuestionarioQuestoes",
                columns: table => new
                {
                    QuestionarioID = table.Column<int>(nullable: false),
                    QuestaoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionarioQuestoes", x => new { x.QuestionarioID, x.QuestaoID });
                    table.ForeignKey(
                        name: "FK_QuestionarioQuestoes_Questoes_QuestaoID",
                        column: x => x.QuestaoID,
                        principalTable: "Questoes",
                        principalColumn: "QuestaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionarioQuestoes_Questionarios_QuestionarioID",
                        column: x => x.QuestionarioID,
                        principalTable: "Questionarios",
                        principalColumn: "QuestionarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoGuias",
                columns: table => new
                {
                    AvaliacaoGuiaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Avaliacao = table.Column<double>(nullable: false),
                    GuiaID = table.Column<int>(nullable: false),
                    NumeroAvaliacoes = table.Column<int>(nullable: false),
                    RespostaQuestionarioID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoGuias", x => x.AvaliacaoGuiaID);
                    table.ForeignKey(
                        name: "FK_AvaliacaoGuias_Guias_GuiaID",
                        column: x => x.GuiaID,
                        principalTable: "Guias",
                        principalColumn: "GuiaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoGuias_RespostaQuestionarios_RespostaQuestionarioID",
                        column: x => x.RespostaQuestionarioID,
                        principalTable: "RespostaQuestionarios",
                        principalColumn: "RespostaQuestionarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoTrilhos",
                columns: table => new
                {
                    AvaliacaoTrilhoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Avaliacao = table.Column<double>(nullable: false),
                    NumeroAvaliacoes = table.Column<int>(nullable: false),
                    RespostaQuestionarioID = table.Column<int>(nullable: true),
                    TrilhoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoTrilhos", x => x.AvaliacaoTrilhoID);
                    table.ForeignKey(
                        name: "FK_AvaliacaoTrilhos_RespostaQuestionarios_RespostaQuestionarioID",
                        column: x => x.RespostaQuestionarioID,
                        principalTable: "RespostaQuestionarios",
                        principalColumn: "RespostaQuestionarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvaliacaoTrilhos_Trilhos_TrilhoID",
                        column: x => x.TrilhoID,
                        principalTable: "Trilhos",
                        principalColumn: "TrilhoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoGuias_GuiaID",
                table: "AvaliacaoGuias",
                column: "GuiaID");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoGuias_RespostaQuestionarioID",
                table: "AvaliacaoGuias",
                column: "RespostaQuestionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoTrilhos_RespostaQuestionarioID",
                table: "AvaliacaoTrilhos",
                column: "RespostaQuestionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoTrilhos_TrilhoID",
                table: "AvaliacaoTrilhos",
                column: "TrilhoID");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoTrilhos_TrilhoID",
                table: "EstadoTrilhos",
                column: "TrilhoID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionarioQuestoes_QuestaoID",
                table: "QuestionarioQuestoes",
                column: "QuestaoID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionarioQuestoes_QuestionarioID",
                table: "QuestionarioQuestoes",
                column: "QuestionarioID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_TipoQuestaoID",
                table: "Questoes",
                column: "TipoQuestaoID");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaQuestionarios_QuestionarioID",
                table: "RespostaQuestionarios",
                column: "QuestionarioID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RespostaQuestionarios_TuristaID",
                table: "RespostaQuestionarios",
                column: "TuristaID");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhos_DificuldadeID",
                table: "Trilhos",
                column: "DificuldadeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoGuias");

            migrationBuilder.DropTable(
                name: "AvaliacaoTrilhos");

            migrationBuilder.DropTable(
                name: "EstadoTrilhos");

            migrationBuilder.DropTable(
                name: "QuestionarioQuestoes");

            migrationBuilder.DropTable(
                name: "Guias");

            migrationBuilder.DropTable(
                name: "RespostaQuestionarios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Trilhos");

            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "Questionarios");

            migrationBuilder.DropTable(
                name: "Turistas");

            migrationBuilder.DropTable(
                name: "Dificuldades");

            migrationBuilder.DropTable(
                name: "TipoQuestoes");
        }
    }
}
