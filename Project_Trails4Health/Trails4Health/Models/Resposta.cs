using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Resposta
    {
        public int RespostaQuestionarioID { get; set; }
        public int Resposta_ { get; set; }

        public Questao Questao { get; set; }
        public int QuestaoID { get; set; }

        public Turista Turista { get; set; }
        public int TuristaID { get; set; }
    }
}
