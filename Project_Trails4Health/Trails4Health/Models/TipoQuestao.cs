using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class TipoQuestao
    {
        public int TipoQuestaoID { get; set; }
        public string TipoQ { get; set; }

        public ICollection<Questao> Questoes { get; set; }
    }
}
