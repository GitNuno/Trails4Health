using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace Trails4Health.Data - orig.
namespace Trails4Health.Models
{
    // class DbContext mapea BD
    // instancio esta classe na minha [EFRepository:IRepository] 
    public class ApplicationDbContext : DbContext
    {
        // base(options) mm que super: cria BD com as options
        // permite-me ter acessso ao que está no modelo
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // config. base dados com os modelos: digo onde vou passar a BD
        // tenho de fazer para cada tabela 
        public DbSet<Trilho> Trilhos { get; set; }
        // +++ aqui aparecem os DbSet<MyModels>  ???    }
    }
}