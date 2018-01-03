using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class ViewModelTrilho
    {
        public int TrilhoID { get; set; }

        [Required(ErrorMessage = "Introduza nome do Trilho")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Nome tem entre 2-50 caracteres")] // entre 2-50 caracteres
        [RegularExpression(@"([^_^0-9]+)", ErrorMessage = "Nome Inválido")] // excepto "_" ou numeros 
        public string TrilhoNome { get; set; }

        [Required(ErrorMessage = "Introduza inicio do Trilho")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Inicio tem entre 2-50 caracteres")] // entre 2-50 caracteres
        [RegularExpression(@"([^_^0-9]+)", ErrorMessage = "Inicio Inválido")] // excepto "_" ou numeros 
        public string TrilhoInicio { get; set; }

        [Required(ErrorMessage = "Introduza fim do Trilho")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Fim tem entre 2-50 caracteres")] // entre 2-50 caracteres
        [RegularExpression(@"([^_^0-9]+)", ErrorMessage = "Fim Inválido")] // excepto "_" ou numeros 
        public string TrilhoFim { get; set; }

        [Required(ErrorMessage = "Introduza detalhes do Trilho")]
        [StringLength(700, MinimumLength = 5, ErrorMessage = "Detalhes tem entre 5-700 caracteres")] // entre 5-700 caracteres
        public string TrilhoDetalhes { get; set; }

        [Required(ErrorMessage = "Introduza Sumario do Trilho")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Sumario tem entre 5-200 caracteres")] // entre entre 5-200 caracteres
        public string TrilhoSumario { get; set; }


        [Required(ErrorMessage = "Introduza Distancia do Trilho")]
        [RegularExpression(@"([^a-zA-Z^\sÇ^]{1,6})", ErrorMessage = "Distancia Inválida - " +
            "introduza apenas valores numericos sem espaços num maximo de 6 caracteres")] // excepto letras, espaços e "ç", max: 6 caracteres
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
