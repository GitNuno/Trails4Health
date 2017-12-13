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
            if (context.TiposRespostas.Any())
            {
                return;   // ... a DB já tem pelo menos um registo.
            }

            var tiposRepostas = new TipoResposta[]
            {
                new TipoResposta{TipoRespostaID=2, Descricao="Sim/Não"},
                new TipoResposta{TipoRespostaID=3, Descricao="1 - Discordo | 3 - Concordo"},
                new TipoResposta{TipoRespostaID=5, Descricao="1 - Discordo em Absoluto | 5 - Concordo Plenamente"}
            };
            foreach (TipoResposta tr in tiposRepostas)
            {
                context.TiposRespostas.Add(tr);
            }
            context.SaveChanges();

            var questoesAvaliacaoTrilho = new QuestaoAvaliacaoTrilho[]
            {
                new QuestaoAvaliacaoTrilho{QuestaoID=1, NomeQuestao="Classifique globalmente este trilho?", Desactivada=false, TipoRespostaID=5},
                new QuestaoAvaliacaoTrilho{QuestaoID=2, NomeQuestao="O trilho continha sinalização adequada?", Desactivada=false, TipoRespostaID=2},
                new QuestaoAvaliacaoTrilho{QuestaoID=3, NomeQuestao="Como classifica este trilho quanto ao grau de dificuldade?", Desactivada=false, TipoRespostaID=5}
            };
            foreach (QuestaoAvaliacaoTrilho qat in questoesAvaliacaoTrilho)
            {
                context.QuestoesAvalicaoTrilhos.Add(qat);
            }
            context.SaveChanges();

            var questoesAvaliacaoGuia = new QuestaoAvalicaoGuia[]
            {
                new QuestaoAvalicaoGuia{QuestaoID=1, NomeQuestao="Classifique globalmente este trilho?", Desactivada=false, TipoRespostaID=5},
                new QuestaoAvalicaoGuia{QuestaoID=2, NomeQuestao="O guia percorreu o trilho com um ritmo adequado à dificuldade do trilho?", Desactivada=false, TipoRespostaID=5},
                new QuestaoAvalicaoGuia{QuestaoID=3, NomeQuestao="O guia fez pausas nos locais assinalados como sendo de interesse?", Desactivada=false, TipoRespostaID=5},
            };
            foreach (QuestaoAvalicaoGuia qag in questoesAvaliacaoGuia)
            {
                context.QuestoesAvalicaoGuias.Add(qag);
            }
            context.SaveChanges();
        }
    }
}
