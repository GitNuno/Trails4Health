using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class AvaliacaoGuia
    {
        public int AvaliacaoGuiaID { get; set; }

        public Guia Guia { get; set; }
        public int GuiaID { get; set; }

        public double Avaliacao { get; set; }
        public int NumeroAvaliacoes { get; set; }
    }
}
