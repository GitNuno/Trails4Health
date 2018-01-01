using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Turista
    {
        public int TuristaID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Morada { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public int Nif { get; set; }
    }
}
