using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Turista
    {
        public int TuristaID { get; set; } 
        public String Nome{ get; set; }
        public String Morada{ get; set; } 
        public String Contribuinte{ get; set; }
        public int Idade{ get; set; }
        public int Telefone { get; set; }
    }
}
