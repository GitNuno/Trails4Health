using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class ReservaGuia
    {
        public int ReservaGuiaID { get; set; }
        public DateTime ReservaParaDia { get; set; }

        public Guia Guia { get; set; }
        public int GuiaID { get; set; }

        public Turista Turista { get; set; }
        public int TuristaID { get; set; }
    }
}
