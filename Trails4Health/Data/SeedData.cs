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
            // EnsureTrilhosPopulated(dbContext);
            dbContext.SaveChanges();
        } //_end_EnsurePopulated ---------------------------

        private static void EnsureTrilhosPopulated(ApplicationDbContext dbContext)
        {
            // nota: Em ApplicationDbContext temos campo: DbSet<Product> Products { get; set; }
            dbContext.Trilhos.AddRange(
                 new Trilho { Nome = "Fojo", Foto = "~/images/intro-pic.jpg", Detalhes = "Este trilho é curto, com uma extensão de 3 km, percorre-se numa media de 1h00, contem poucas subidas e começa" +
                 " na Tapada e termina em um rio no Fojo no meio da sera, contem cerca de 8 curvas e 5 subidas. Durante esta subida inicial do percurso," +
                 "pode apreciar diversos moinhos antigos.",
                     Desativado = false, Inicio = "Tapada", Fim = "Fojo",  Distancia = 5000m
                 },
                 new Trilho { Nome = "Pateiro", Foto = "~/images/intro-pic.jpg", Detalhes = "Este trilho é longo normalmente recomendada a turista mais jovens, tem uma extensão de 10 km, percorre-se numa media de 3h30" +
                 "começa com uma subida de 300 metros no monte alto e termina no Pateiro, durante este trilho pode -se apreciar várias paisagens lindas contempando assim a beleza da Natureza, contém 15 subidas e 13 curcas. ",
                     Desativado = false, Inicio = "Monte alto", Fim = "Pateiro", Distancia = 20000m
                 },
                 new Trilho { Nome = "Vale Lobos", Foto = "~/images/intro-pic.jpg", Detalhes = "Este trilho conhecido com este nome pelo fato de passar em uma zona em que havia muitos lobos, é um trilho médio com uma" +
                 " extensão de 5 km. contém 6 subidas e 4 curvas, Inicia na Bacia do geres e termina no Vale Lobos.",
                     Desativado = false, Inicio = "Bacia do geres", Fim = "Vale Lobos", Distancia = 27000m
                 },
                 new Trilho { Nome = "Regada", Foto = "~/images/intro-pic.jpg", Detalhes = "Este Trilho é curto, com 4 km de extensão, 6 curvas e 3 subidas, paisagens lindas, e faz -se numa media de 1h15.",
                     Desativado = false, Inicio = "Pocinha", Fim = "Regada", Distancia = 15000m
                 },
                 new Trilho { Nome = "Coitadas", Foto = "~/images/intro-pic.jpg", Detalhes = "Este trilho é longo, contem no total um percurso de 11 km, tem seu inicio em Lameira, com muitas curvas e subidas e termina" +
                 "Coitadas, percorre-se numa media  de 4h00.",
                     Desativado = false, Inicio = "Lameira", Fim = "Coitadas", Distancia = 13000m
                 }
            );
        }
    }
}