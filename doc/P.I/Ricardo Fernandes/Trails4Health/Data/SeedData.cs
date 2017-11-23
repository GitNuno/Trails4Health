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
            // Limpa base dados
           // dbContext.Trilhos.RemoveRange(dbContext.Trilhos);

            if (!dbContext.Trilhos.Any())
            {
                EnsureTrilhosPopulated(dbContext);
            }
            dbContext.SaveChanges();
        } //_end_EnsurePopulated ---------------------------



        private static void EnsureTrilhosPopulated(ApplicationDbContext dbContext)
        {
            // nota: Em ApplicationDbContext temos campo: DbSet<Trilho> Trilhos { get; set; }
            dbContext.Trilhos.AddRange(
                 new Trilho { Nome = "Fojo", Foto = "/images/intro-pic.jpg", Detalhes = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado = false, Inicio = "Tapada", Fim = "Fojo",  Distancia = 5m
                 },
                 new Trilho { Nome = "Pateiro", Foto = "/images/intro-pic.jpg", Detalhes = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado = false, Inicio = "Monte alto", Fim = "Pateiro", Distancia = 12m
                 },
                 new Trilho { Nome = "Vale Lobos", Foto = "/images/intro-pic.jpg", Detalhes = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado = false, Inicio = "Bacia do geres", Fim = "Vale Lobos", Distancia = 27m
                 },
                 new Trilho { Nome = "Regada", Foto = "/images/intro-pic.jpg", Detalhes = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado = false, Inicio = "Pocinha", Fim = "Regada", Distancia = 150m
                 },
                 new Trilho { Nome = "Coitadas", Foto = "/images/intro-pic.jpg", Detalhes = "Lorem ipsum dolor sit amet, consectetur Magnam soluta doloreos excepturi veritatis",
                     Desativado = false, Inicio = "Lameira", Fim = "Coitadas", Distancia = 13m
                 }
            );
        }
    }
}