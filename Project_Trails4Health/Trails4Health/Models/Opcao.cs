using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Opcao
    {
        public int OpcaoID { get; set; }
        
        public Questao Questao { get; set; }
        public int QuestaoID { get; set; }

        public ICollection<Resposta> Respostas { get; set; } 
    }
}
