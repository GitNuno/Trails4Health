using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public static class SeedData
    {
        // garante que BD está populada
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            // 
            ApplicationDbContext dbContext = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));

            if (!dbContext.Trilhos.Any())
            {
                EnsureTrilhosPopulated(dbContext);
            }

            dbContext.SaveChanges();
        } //_end_EnsurePopulated ---------------------------

        private static void EnsureTrilhosPopulated(ApplicationDbContext dbContext)
        {
            // nota: Em ApplicationDbContext temos campo: DbSet<Product> Products { get; set; }
            dbContext.Trilhos.AddRange(
                 new Trilho { Nome_Trilho = "Fojo", Foto_Trilho = "~/ images / intro-pic.jpg", Detalhes_Trilho = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado_Trilho = false, Inicio_Trilho = "Tapada", Fim_Trilho = "Fojo",  Distancia_Trilho = "5 km"
                 },
                 new Trilho { Nome_Trilho = "Pateiro", Foto_Trilho = "~/ images / intro-pic.jpg", Detalhes_Trilho = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado_Trilho = false, Inicio_Trilho = "Monte alto", Fim_Trilho = "Pateiro", Distancia_Trilho = "20 km"
                 },
                 new Trilho { Nome_Trilho = "Vale Lobos", Foto_Trilho = "~/ images / intro-pic.jpg", Detalhes_Trilho = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado_Trilho = false, Inicio_Trilho = "Bacia do geres", Fim_Trilho = "Vale Lobos", Distancia_Trilho = "10 km"
                 },
                 new Trilho { Nome_Trilho = "Regada", Foto_Trilho = "~/ images / intro-pic.jpg", Detalhes_Trilho = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado_Trilho = false, Inicio_Trilho = "Pocinha", Fim_Trilho = "Regada", Distancia_Trilho = "15 km"
                 },
                 new Trilho { Nome_Trilho = "Coitadas", Foto_Trilho = "~/ images / intro-pic.jpg", Detalhes_Trilho = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado_Trilho = false, Inicio_Trilho = "Lameira", Fim_Trilho = "Coitadas", Distancia_Trilho = "27 km"
                 }
            );
        }
    }
}