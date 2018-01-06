using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Questionario
    {
        public int QuestionarioID { get; set; }
        public DateTime DataRespostas { get; set; }

        public ICollection<QuestionarioQuestao> QuestionarioQuestoes { get; set; }
        //public QuestionarioQuestao QuestionarioQuestao { get; set; }
        //public RespostaQuestionario RespostaQuestionario { get; set; }
    }
}
