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
                 new Trilho { Nome = "Loriga", Foto = "/images/loriga.jpg", Detalhes = "Este trilho é curto, com uma extensão de 5 km e percorre-se numa média de 1h00. Contem poucas subidas começa" +
                 " na alta de Loriga e termina junto á Ribeira de S.Bento.",
                     Desativado = false, Inicio = "Alta de Loriga", Fim = "Ribeira de S.Bento",  Distancia = 5m
                 },
                 new Trilho { Nome = "Covão da Ametade", Foto = "/images/covao.jpg", Detalhes = "Este trilho é longo normalmente recomendada a turista mais jovens, tem uma extensão de 10 km, percorre-se numa media de 3h00" +
                 " começa com uma subida de 300 metros em Covão da Ametade e termina em Monte alto.",
                     Desativado = false, Inicio = "Covão da Ametade", Fim = "Monte alto", Distancia = 10m
                 },
                 new Trilho { Nome = "Vale Lobos", Foto = "/images/linhares.jpg", Detalhes = "Este trilho é de tamanho médio, perfaz uma distancia de 7 km," +
                 " começa em Vale Lobos e termina em Linhares da Beira.",
                     Desativado = false, Inicio = "Vale Lobos", Fim = "Linhares da Beira", Distancia = 7m
                 },
                 new Trilho { Nome = "Alvoco da Serra", Foto = "/images/alvoco.jpg", Detalhes = "Situado no coração da Serra da Estrela, este Trilho é curto com 4 km de extensão, constituido por paisagens majestosas e faz-se numa media de 1h15.",
                     Desativado = false, Inicio = "Alvoco da Serra", Fim = "Poço do Inferno", Distancia = 4m
                 },
                 new Trilho { Nome = "Vale do Rossim", Foto = "/images/rossim.jpg", Detalhes = "Este trilho é longo, perfaz um percurso de 11 km, tem seu inicio em Vale do Rossim, com muitas curvas e subidas, termina" +
                 " na Torre e percorre-se numa media de 3h30.",
                     Desativado = false, Inicio = "Vale do Rossim", Fim = "Torre", Distancia = 11m
                 }
            );
        }
    }
}