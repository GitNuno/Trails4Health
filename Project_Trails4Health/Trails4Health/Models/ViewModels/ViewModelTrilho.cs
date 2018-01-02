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
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Nome tem entre 2-50 caracteres")] // entre 2-50 caracteres
        [RegularExpression(@"([A-Za-z-\s{1}]+)", ErrorMessage = "Nome Inválido")] // sem numeros ou "_"
        public string TrilhoNome { get; set; }

        [Required(ErrorMessage = "Introduza inicio do Trilho")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Inicio tem entre 2-50 caracteres")] // entre 2-50 caracteres
        [RegularExpression(@"([A-Za-z-\s{1}]+)", ErrorMessage = "Inicio Inválido")] // sem numeros ou "_"
        public string TrilhoInicio { get; set; }

        [Required(ErrorMessage = "Introduza fim do Trilho")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Fim tem entre 2-50 caracteres")] // entre 2-50 caracteres
        [RegularExpression(@"([A-Za-z-~\s{1}]+)", ErrorMessage = "Fim Inválido")] // sem numeros ou "_"
        public string TrilhoFim { get; set; }

        [Required(ErrorMessage = "Introduza detalhes do Trilho")]
        [StringLength(700, MinimumLength = 5, ErrorMessage = "Detalhes tem entre 5-700 caracteres")] // entre 5-700 caracteres
        public string TrilhoDetalhes { get; set; }

        [Required(ErrorMessage = "Introduza Sumario do Trilho")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Sumario tem entre 5-200 caracteres")] // entre entre 5-200 caracteres
        public string TrilhoSumario { get; set; }

        [Required(ErrorMessage = "Introduza Distancia do Trilho")]
        public decimal TrilhoDistancia { get; set; }

        [Required(ErrorMessage = "Escolha uma foto")]
        public string TrilhoFoto { get; set; } // mais tarde vai ser na base dados

        public bool TrilhoDesativado { get; set; } = false;

        public int DificuldadeID { get; set; }
        // public int DificuldadeNome { get; set; }

        public int EstadoID { get; set; }
        // public int EstadoNome { get; set; }
    }
}
