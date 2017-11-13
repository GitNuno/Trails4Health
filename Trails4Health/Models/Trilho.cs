using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trilho
    {
        public int TrilhoID { get; set; } // tem de ter este formato para reconhecer pk: nomeID !!
        public string Nome_Trilho { get; set; }
        public string Foto_Trilho { get; set; } // +++ endereço da foto??
        public string Detalhes_Trilho { get; set; }
        public bool Desativado_Trilho { get; set; }
        public string Inicio_Trilho { get; set; }
        public string Fim_Trilho { get; set; }
        public string Distancia_Trilho { get; set; } // int ??
        //public int ID_Dificuldade { get; set; } // FK /*??*/

    }
}
