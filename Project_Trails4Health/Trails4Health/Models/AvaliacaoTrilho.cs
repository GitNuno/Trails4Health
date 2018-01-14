using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class AvaliacaoTrilho
    {
        public int AvaliacaoTrilhoID { get; set; }

        public Trilho Trilho { get; set; }
        public int TrilhoID { get; set; }

        public double Avaliacao { get; set; }
        public int NumeroAvaliacoes { get; set; }
    }
}
