using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Opcao
    {
        public int OpcaoID { get; set; }
        public int NumeroOpcoes { get; set; }
                
        public ICollection<Questao> Questoes { get; set; }
    }
}
