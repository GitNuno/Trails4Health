using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Range(100000000, 999999999)]
        public int Nif { get; set; }

        public ICollection<Resposta> Respostas { get; set; }
        //public ICollection<RespostaQuestionario> RespostaQuestionarios { get; set; }
    }
}
