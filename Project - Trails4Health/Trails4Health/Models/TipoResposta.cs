using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class TipoResposta
    {
        public int TipoRespostaID { get; set; }
        public string Descricao { get; set; }

        public ICollection<QuestaoAvaliacaoTrilho> QuestoesAvaliacaoTrilhos { get; set; }
        public ICollection<QuestaoAvalicaoGuia> QuestoesAvalicaoGuias { get; set; }
    }
}
