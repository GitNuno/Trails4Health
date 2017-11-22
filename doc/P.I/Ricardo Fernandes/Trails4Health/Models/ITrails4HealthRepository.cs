using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public interface ITrails4HealthRepository
    {
        // +++ crio apenas 1 class interface para todos modelos(tabelas) e com varios IEnumerable<MyModel> ???
        // +++ por sua vez EF()Repository implementa esta classe e cada destes IEnumerable<MyModel> é preenchido
        //     com BD usando ApplicationDbContext ??????
        // permite-me criar qualquer tipo de "repositorio" (neste caso de Trilhos) a partir desta interface
        IEnumerable<Trilho> Trilhos { get; }
    }
}
