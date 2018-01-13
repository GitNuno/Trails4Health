using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class ViewModelListaTrilhos
    {
        public IEnumerable<Trilho> Trilho { get; set; }
        public InfoPaginacao InfoPaginacao { get; set; }
    }
}
