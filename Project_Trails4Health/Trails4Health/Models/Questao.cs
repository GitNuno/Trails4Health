using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Questao
    {
        //public int QuestaoID { get; set; }
        public string Nome { get; set; }

        public TipoResposta TipoResposta { get; set; }
        public TipoQuestao TipoQuestao { get; set; }

        public int TipoRespostaID { get; set; }
        public int TipoQuestaoID { get; set; }
    }
}
