using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Questao
    {
        public int QuestaoID { get; set; }
        public string NomeQuestao { get; set; }
        public bool Desactivada { get; set; }
        public string Descricao { get; set; }

        public ICollection<RespostaAvaliacao> RespostasAvaliacao { get; set; }
    }
}
