using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class RespostaQuestionario
    {
        public int RespostaQuestionarioID { get; set; }

        public Questionario Questionario { get; set; }
        public int QuestionarioID { get; set; }

        public Turista Turista { get; set; }
        public int TuristaID { get; set; }

        public DateTime Data { get; set; }

        public ICollection<AvaliacaoGuia> AvaliacaoGuias { get; set; }
        public ICollection<AvaliacaoTrilho> AvaliacaoTrilhos { get; set; }
       // public ICollection<Resposta> Respostas { get; set; }
    }
}