using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    // Esta classe tem o mesmo objectivo da classe "SeedData", ou seja, colocar alguns dados de teste na base de dados 
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Se não encontrou um registo ...
            if (!context.TipoQuestoes.Any())
            {
                context.TipoQuestoes.AddRange(
                new TipoQuestao { Nome = "Trilho" },
                new TipoQuestao { Nome = "Guia" }
                );
                context.SaveChanges();
            }

            if (!context.Questoes.Any())
            {
                context.Questoes.AddRange(
                new Questao { NomeQuestao = "Classifique globalmente este trilho?", Desactivada = false, TipoResposta = "1 - Horrível | 5 - Excelente", ValorMaximo = 5, ValorMinimo = 1, NumeroOpcoes = 5, TipoQuestaoID = 1 },
                new Questao { NomeQuestao = "O trilho continha sinalização adequada?", Desactivada = false, TipoResposta = "Sim | Não", ValorMaximo = 5, ValorMinimo = 1, NumeroOpcoes = 2, TipoQuestaoID = 1 },
                new Questao { NomeQuestao = "Como classifica este trilho quanto ao grau de dificuldade?", Desactivada = false, TipoResposta = "1 - Muito Difícil | 5 - Muito Fácil", ValorMaximo = 5, ValorMinimo = 1, NumeroOpcoes = 5, TipoQuestaoID = 1 },
                new Questao { NomeQuestao = "O guia demonstrou conhecimento do trilho?", Desactivada = false, TipoResposta = "1 - Discordo em absoluto | 5 - Concordo plenamente", ValorMaximo = 5, ValorMinimo = 1, NumeroOpcoes = 5, TipoQuestaoID = 2 },
                new Questao { NomeQuestao = "O guia percorreu o trilho com um ritmo adequado à dificuldade do trilho?", Desactivada = false, TipoResposta = "1 - Discordo | 3 - Concordo", ValorMaximo = 5, ValorMinimo = 1, NumeroOpcoes = 3, TipoQuestaoID = 2 },
                new Questao { NomeQuestao = "O guia fez pausas nos locais assinalados como sendo de interesse?", Desactivada = false, TipoResposta = "Sim | Não", ValorMaximo = 5, ValorMinimo = 1, NumeroOpcoes = 2, TipoQuestaoID = 2 }
                );
                context.SaveChanges();
            }
        }
    }
}
