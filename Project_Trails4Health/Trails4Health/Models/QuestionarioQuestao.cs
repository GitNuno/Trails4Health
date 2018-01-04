using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class QuestionarioQuestao
    {
        // classe formada por chaves primárias compostas

        public Questao Questao { get; set; }
        public int QuestaoID { get; set; }

        public Questionario Questionario { get; set; }
        public int QuestionarioID { get; set; }
    }
}
