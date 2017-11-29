using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class QuestoesAvaliacaoTrilho
    {
        // ATRIBUTOS DE QUESTOES AVALIACAO TRILHO
        public int QuestaoID { get; set; }
        public string NomeQuestao { get; set; }
        public int TipoRespostaID { get; set; }
        public Boolean Desativada { get; set; }
    }
}
