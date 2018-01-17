using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public static class SeedData
    {

        // DIFICULDADE
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
        public const string OBSERVACAO_DIFICULDADE_2 = "Trilho de média exigência fisica";
        public const string OBSERVACAO_DIFICULDADE_3 = "Trilho de pequena exigência fisica";

        // ESTADO
        // ID Estado
        public const int ABERTO = 1;
        public const int FECHADO = 2;
        // Nome Estado
        public const string NOME_ESTADO_1 = "Aberto";
        public const string NOME_ESTADO_2 = "Fechado";

        // TRILHOS
        public static Trilho faias = new Trilho
        {
            Nome = "Faias",  
            ImagemTrilho = new Byte[]{0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49,0x46, 0x00, 0x01, 0x01, 0x01, 0x00, 0x60,
                0x00, 0x60, 0x00,0x00, 0xFF, 0xE1, 0x00, 0x22, 0x45, 0x78, 0x69, 0x66, 0x00, 0x00, 0x4D, 0x4D, 0x00, 0x2A,
                0x00, 0x00, 0x00, 0x08, 0x00, 0x01, 0x01, 0x12, 0x00, 0x03, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFE, 0x00, 0x3C, 0x43, 0x52, 0x45, 0x41, 0x54, 0x4F, 0x52, 0x3A,
                0x20, 0x67, 0x64, 0x2D, 0x6A, 0x70, 0x65, 0x67, 0x20, 0x76, 0x31, 0x2E, 0x30, 0x20, 0x28, 0x75, 0x73, 0x69,
                0x6E, 0x67, 0x20, 0x49, 0x4A, 0x47, 0x20, 0x4A, 0x50, 0x45, 0x47, 0x20, 0x76, 0x36, 0x32, 0x29, 0x2C, 0x20,
                0x71, 0x75, 0x61, 0x6C, 0x69, 0x74, 0x79, 0x20, 0x3D, 0x20, 0x38, 0x30, 0x0A, 0x00, 0xFF, 0xDB, 0x00,
                0x43, 0x00, 0x02, 0x01, 0x01, 0x02, 0x01 },
            Detalhes = "Queres caminhar entre gnomos, " +
                 "florestas encantadas, cogumelos selvagens e ouvir o crepitar das folhas debaixo dos pés ? Tens de fazer a " +
                 "Rota das Faias.Ainda que seja mais aconselhável fazer o percurso pedestre no outono para podermos apreciar " +
                 "as cores quentes da folhagem das faias, este é um bosque para descobrir todo o ano.",
            Sumario = "Este é um bosque para descobrir todo o ano. O percurso começa na zona de Manteigas, mais " +
                     "concretamente junto à Cruz das Jugadas.",
            Desativado = false,
            Inicio = "Manteigas",
            Fim = "Cruz das Jugadas",
            Distancia = 15m,
            DificuldadeID = MEDIA // Nota: DificuldadeID na tabela Dificuldade é criado automaticamente. Se já tiverem sido
                                  // criados registos na tabela Dificuldade antes de correr SeedData, vai haver conflito
                                  // pois o 1º ID já não é 1 - SOLUÇÃO: recriar BD Trails4Health
        };
                
        public static Trilho covao = new Trilho
        {
            Nome = "Covão dos Conchos",            
            Detalhes = "O funil não é mais do que um túnel construído na década de ’50 e que leva as águas recolhidas da " +
                "Ribeira das Naves e as encaminha para a Lagoa Comprida, bem mais abaixo.O túnel tem 48 m de coroamento e " +
                "1519 metros de comprimento. Para aqui chegar basta fazer uma caminhada de 8 km(quatro para cada lado), " +
                "desde a Lagoa Comprida.",
            Sumario = "O Covão dos Conchos tornou-se famoso quando no início deste ano uma série de filmes gravados com um " +
                "drone mostrava as águas da lagoa a precipitarem-se num gigantesco funil.",
            Desativado = false,
            Inicio = "Lagoa Comprida",
            Fim = "Covão dos Conchos",
            Distancia = 8m,
            DificuldadeID = PEQUENA // Nota: DificuldadeID na tabela Dificuldade é criado automaticamente. Se já tiverem sido
                                    // criados registos na tabela Dificuldade antes de correr SeedData, vai haver conflito
                                    // pois o 1º ID já não é 1 - SOLUÇÃO: recriar BD Trails4Health
        };

        // Popular BD
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            // 
            ApplicationDbContext dbContext = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
            // Limpar registos base dados, Nota: ATENÇÃO aos IDs Dificuldades e Estado!! 
            dbContext.Trilhos.RemoveRange(dbContext.Trilhos);
            dbContext.EstadoTrilhos.RemoveRange(dbContext.EstadoTrilhos);
            //dbContext.Dificuldades.RemoveRange(dbContext.Dificuldades);
            //dbContext.Estados.RemoveRange(dbContext.Estados);


            // se não houver qq registo nestas tabelas...
            if (!dbContext.Dificuldades.Any())
            {
                EnsureDificuldadesPopulated(dbContext);
            }
            dbContext.SaveChanges();

            if (!dbContext.Trilhos.Any())
            {
                EnsureTrilhosPopulated(dbContext);
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
            //dbContext.Trilhos.AddRange(faias, covao);
            dbContext.Trilhos.AddRange(faias);
        }

        private static void EnsureDificuldadesPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Dificuldades.AddRange(
                new Dificuldade { Nome = NOME_DIFICULDADE_1, Observacao = OBSERVACAO_DIFICULDADE_1 },
                new Dificuldade { Nome = NOME_DIFICULDADE_2, Observacao = OBSERVACAO_DIFICULDADE_2 },
                new Dificuldade { Nome = NOME_DIFICULDADE_3, Observacao = OBSERVACAO_DIFICULDADE_3 }
                );
        }

        private static void EnsureEstadosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Estados.AddRange(
                new Estado { Nome = NOME_ESTADO_1 },
                new Estado { Nome = NOME_ESTADO_2 }
                );
        }

        // Nota: EstadoID na tabela Estado é criado automaticamente. Se já tiverem sido sido criados registos na tabela Estado
        // antes de correr SeedData, vai haver conflito pois o 1º ID já não é 1 - SOLUÇÃO: recriar BD Trails4Health
        private static void EnsureEstadoTrilhosPopulated(ApplicationDbContext dbContext)
        {   
            dbContext.EstadoTrilhos.AddRange(
                new EstadoTrilho { Trilho = faias, EstadoID = ABERTO, DataInicio = DateTime.Now, DataFim = null }
                //new EstadoTrilho { Trilho = covao, EstadoID = ABERTO, DataInicio = DateTime.Now, DataFim = null }
                );
        }
    
    }
}