using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trilho
    {
        public int TrilhoID { get; set; } // tem de ter este formato para reconhecer pk: nomeID !!
        public string Nome { get; set; }
        public string Foto { get; set; } // +++ endereço da foto??
        public string Detalhes { get; set; }
        public bool Desativado { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public decimal Distancia { get; set; }
        public int DificuldadeID { get; set; } // FK /*??*/
    }
}
