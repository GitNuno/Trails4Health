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

            if (!context.Opcoes.Any())
            {
                context.Opcoes.AddRange(
                new Opcao { NumeroOpcoes = 2 },
                new Opcao { NumeroOpcoes = 3 },
                new Opcao { NumeroOpcoes = 5 }
                 );
                context.SaveChanges();
            }

            if (!context.Questoes.Any())
            {
                context.Questoes.AddRange(
                new Questao { NomeQuestao = "Classifique globalmente este trilho?", Desactivada = false, Descricao = "1 - Horrível | 5 - Excelente", OpcaoID = 3 },
                new Questao { NomeQuestao = "O trilho continha sinalização adequada?", Desactivada = false, Descricao = "Sim | Não", OpcaoID = 1 },
                new Questao { NomeQuestao = "Como classifica este trilho quanto ao grau de dificuldade?", Desactivada = false, Descricao = "1 - Muito Difícil | 5 - Muito Fácil", OpcaoID = 3 }
                //new Questao { NomeQuestao = "O guia demonstrou conhecimento do trilho?", Desactivada = false, TipoResposta = "1 - Discordo em absoluto | 5 - Concordo plenamente", ValorMaximo = 5, ValorMinimo = 1, NumeroOpcoes = 5 },
                //new Questao { NomeQuestao = "O guia percorreu o trilho com um ritmo adequado à dificuldade do trilho?", Desactivada = false, TipoResposta = "1 - Discordo | 3 - Concordo", ValorMaximo = 5, ValorMinimo = 1, NumeroOpcoes = 3 },
                //new Questao { NomeQuestao = "O guia fez pausas nos locais assinalados como sendo de interesse?", Desactivada = false, TipoResposta = "Sim | Não", ValorMaximo = 5, ValorMinimo = 1, NumeroOpcoes = 2 }
                );
                context.SaveChanges();
            }

            if (!context.Opcoes.Any())
            {
                context.Opcoes.AddRange(
                new Opcao { NumeroOpcoes = 2 },
                new Opcao { NumeroOpcoes = 3 },
                new Opcao { NumeroOpcoes = 5 }
                 );
                context.SaveChanges();
            }

            if (!context.Guias.Any())
            {
                context.Guias.AddRange(
                new Guia { Nome = "José Esteves", Telefone = "271100100", Email = "jesteves@gmail.com" },
                new Guia { Nome = "Túlio Gonzaga", Telefone = "271100200", Email = "tulio@gmail.com" },
                new Guia { Nome = "António Malaquias", Telefone = "271100300", Email = "amalaquias@gmail.com" }
                 );
                context.SaveChanges();
            }

            if (!context.Turistas.Any()) // Nif's válidos gerados aleatoriamente (https://nif.marcosantos.me/)
            {
                context.Turistas.AddRange(
                new Turista { Nome = "Maurício Abraão", Telefone = "271200100", Email = "mauricio@gmail.com", Nif = 275092879 },
                new Turista { Nome = "Jaime Coelho", Telefone = "271200200", Email = "jcoelho@gmail.com", Nif = 274261154 },
                new Turista { Nome = "Pedro Gama", Telefone = "271200300", Email = "mauricio@gmail.com", Nif = 281910430 }
                 );
                context.SaveChanges();
            }
        }
    }
}
