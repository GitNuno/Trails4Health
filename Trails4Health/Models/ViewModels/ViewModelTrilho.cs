using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class ViewModelTrilho
    {

        [Required(ErrorMessage = "Introduza nome do Trilho")]
        public string TrilhoNome { get; set; }

        [Required(ErrorMessage = "Introduza inicio do Trilho")]
        public string TrilhoInicio { get; set; }

        [Required(ErrorMessage = "Introduza fim do Trilho")]
        public string TrilhoFim { get; set; }

        [Required(ErrorMessage = "Introduza detalhes do Trilho")]
        public string TrilhoDetalhes { get; set; }

        [Required(ErrorMessage = "Introduza Distancia do Trilho")]
        public decimal TrilhoDistancia { get; set; }

        [Required(ErrorMessage = "Escolha uma foto")]
        public string TrilhoFoto { get; set; } // mais tarde vai ser na base dados

        public bool TrilhoDesativado { get; set; } = false;

        public int DificuldadeID { get; set; }

        // public int DificuldadeNome { get; set; }

        //
        public int EstadoID { get; set; }

    }
}
