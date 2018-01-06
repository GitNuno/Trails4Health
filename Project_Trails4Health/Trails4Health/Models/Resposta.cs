using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Resposta
    {
        //public RespostaQuestionario RespostaQuestionario { get; set; }
        //public int RespostaQuestionarioID { get; set; }

        //public Questao Questao { get; set; }
        //public int QuestaoID { get; set; }

        public Turista Turista { get; set; }
        public int TuristaID { get; set; }

        public Opcao Opcao { get; set; }
        public int OpcaoID { get; set; }

        //public int Resposta_ { get; set; }
    }
}
