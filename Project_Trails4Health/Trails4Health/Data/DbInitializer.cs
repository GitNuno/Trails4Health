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

            // Se encontrou um registo ...
            //if (context.TiposRespostas.Any())
            //{
            //    return;   // ... a DB já tem pelo menos um registo.
            //}

            //context.TipoRespostas.AddRange(
            //    new TipoResposta { Descricao = "Sim/Não" },
            //    new TipoResposta { Descricao = "1 - Discordo | 3 - Concordo" },
            //    new TipoResposta { Descricao = "1 - Discordo em Absoluto | 5 - Concordo Plenamente" }
            //);
            //context.SaveChanges();

            //if (context.QuestoesAvalicaoTrilhos.Any())
            //{
            //    return;   
            //}

            //context.QuestaoAvalicaoTrilhos.AddRange(
            //    new QuestaoAvaliacaoTrilho { NomeQuestao = "Classifique globalmente este trilho?", Desactivada = false, TipoRespostaID = 1 },
            //    new QuestaoAvaliacaoTrilho { NomeQuestao = "O trilho continha sinalização adequada?", Desactivada = false,  TipoRespostaID = 2 },
            //    new QuestaoAvaliacaoTrilho { NomeQuestao = "Como classifica este trilho quanto ao grau de dificuldade?", Desactivada = false, TipoRespostaID = 3 }
            //);
            //context.SaveChanges();

            //if (context.QuestoesAvalicaoGuias.Any())
            //{
            //    return;
            //}

            //context.QuestaoAvalicaoGuias.AddRange(
            //    new QuestaoAvaliacaoGuia { NomeQuestao = "Classifique globalmente este trilho?", Desactivada = false, TipoRespostaID = 1 },
            //    new QuestaoAvaliacaoGuia { NomeQuestao = "O guia percorreu o trilho com um ritmo adequado à dificuldade do trilho?", Desactivada = false, TipoRespostaID = 1 },
            //    new QuestaoAvaliacaoGuia { NomeQuestao = "O guia fez pausas nos locais assinalados como sendo de interesse?", Desactivada = false, TipoRespostaID = 1 }
            //    );
            //context.SaveChanges();

            context.TipoQuestoes.AddRange(
                new TipoQuestao { Nome = "Trilho"},
                new TipoQuestao { Nome = "Guia"}
                );
            context.SaveChanges();
        }
    }
}
