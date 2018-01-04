using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public static class SeedData
    {
        // ID Dificuldade
        public const int GRANDE = 1;
        public const int MEDIA = 2;
        public const int PEQUENA = 3;
        // Nome Dificuldade
        public const string NOME_DIFICULDADE_1 = "Grande";
        public const string NOME_DIFICULDADE_2 = "Media";
        public const string NOME_DIFICULDADE_3 = "Pequena";
        // Observaçao Dificuldade
        public const string OBSERVACAO_DIFICULDADE_1 = "Trilho de grande exigencia fisica";
        public const string OBSERVACAO_DIFICULDADE_2 = "Trilho de media exigencia fisica";
        public const string OBSERVACAO_DIFICULDADE_3 = "Trilho de pequena exigencia fisica";

        // ID Estado
        public const int ABERTO = 1;
        public const int FECHADO = 2;
        // Nome Estado
        public const string NOME_ESTADO_1 = "Aberto";
        public const string NOME_ESTADO_2 = "Fechado";

        // garante que BD está populada
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            // 
            ApplicationDbContext dbContext = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
            // Limpa base dados
            //dbContext.Trilhos.RemoveRange(dbContext.Trilhos);
            //dbContext.Dificuldades.RemoveRange(dbContext.Dificuldades);
            //dbContext.Estados.RemoveRange(dbContext.Estados);
            //dbContext.EstadoTrilhos.RemoveRange(dbContext.EstadoTrilhos);

            // se não houver qq registo nestas tabelas...
            if (!dbContext.Trilhos.Any())
            {
                EnsureTrilhosPopulated(dbContext);
            }
            dbContext.SaveChanges();

            if (!dbContext.Dificuldades.Any())
            {
                EnsureDificuldadesPopulated(dbContext);
            }
            dbContext.SaveChanges();

            if (!dbContext.Estados.Any())
            {
                EnsureEstadosPopulated(dbContext);
            }
            dbContext.SaveChanges();

            if (!dbContext.EstadoTrilhos.Any())
            {
                EnsureEstadoTrilhosPopulated(dbContext);
            }
            dbContext.SaveChanges();
        } //_end_EnsurePopulated



        private static void EnsureTrilhosPopulated(ApplicationDbContext dbContext)
        {
            // nota: Em ApplicationDbContext temos campo: DbSet<Trilho> Trilhos { get; set; }
            dbContext.Trilhos.AddRange(
                 new Trilho {TrilhoID = 1, Nome = "Rota das Faias", Foto = "/images/faias.jpg", Detalhes = "Queres caminhar entre gnomos, " +
                 "florestas encantadas, cogumelos selvagens e ouvir o crepitar das folhas debaixo dos pés ? Tens de fazer a " +
                 "Rota das Faias.Ainda que seja mais aconselhável fazer o percurso pedestre no outono para podermos apreciar " +
                 "as cores quentes da folhagem das faias, este é um bosque para descobrir todo o ano.",
                     Sumario = "Este é um bosque para descobrir todo o ano. O percurso começa na zona de Manteigas, mais " +
                     "concretamente junto à Cruz das Jugadas.",
                     Desativado = false, Inicio = "Manteigas", Fim = "Cruz das Jugadas",  Distancia = 15m,
                     DificuldadeID = MEDIA
                 }
                 //,
                 //new Trilho { Nome = "Covão da Ametade", Foto = "/images/covao.jpg", Detalhes = "Este trilho é longo normalmente recomendada a turista mais jovens, tem uma extensão de 10 km, percorre-se numa media de 3h00" +
                 //" começa com uma subida de 300 metros em Covão da Ametade e termina em Monte alto.",
                 //    Desativado = false, Inicio = "Covão da Ametade", Fim = "Monte alto", Distancia = 10m
                 //},
                 //new Trilho { Nome = "Vale Lobos", Foto = "/images/linhares.jpg", Detalhes = "Este trilho é de tamanho médio, perfaz uma distancia de 7 km," +
                 //" começa em Vale Lobos e termina em Linhares da Beira.",
                 //    Desativado = false, Inicio = "Vale Lobos", Fim = "Linhares da Beira", Distancia = 7m
                 //}
            );
        }

        private static void EnsureDificuldadesPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Dificuldades.AddRange(
                new Dificuldade {Nome = NOME_DIFICULDADE_1, Observacao = OBSERVACAO_DIFICULDADE_1},
                new Dificuldade {Nome = NOME_DIFICULDADE_2, Observacao = OBSERVACAO_DIFICULDADE_2},
                new Dificuldade {Nome = NOME_DIFICULDADE_3, Observacao = OBSERVACAO_DIFICULDADE_3}
                );
        }

        private static void EnsureEstadosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Estados.AddRange(
                new Estado {Nome = NOME_ESTADO_1},
                new Estado {Nome = NOME_ESTADO_2}
                );
        }

        private static void EnsureEstadoTrilhosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.EstadoTrilhos.AddRange(
                new EstadoTrilho { TrilhoID = 1, EstadoID = ABERTO, DataInicio = DateTime.Now, DataFim = new DateTime(2018, 01, 27) },
                new EstadoTrilho { TrilhoID = 1, EstadoID = FECHADO, DataInicio = new DateTime(2018, 01, 27) }
                );
        }
    
    }
}