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
        public string TipoResposta { get; set; }
        public int ValorMaximo { get; set; }
        public int ValorMinimo { get; set; }

        [Range(0, 5)]
        public int NumeroOpcoes { get; set; }
        
        public ICollection<Opcao> Opcoes {get; set;}
    }
}
