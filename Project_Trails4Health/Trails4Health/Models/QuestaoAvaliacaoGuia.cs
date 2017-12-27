using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class QuestaoAvaliacaoGuia
    {
        public int QuestaoID { get; set; }
        public string NomeQuestao { get; set; }
        public bool Desactivada { get; set; }
        public int TipoRespostaID { get; set; } // chave estrangeira de TipoResposta

        public TipoResposta TipoResposta;
    }
}
