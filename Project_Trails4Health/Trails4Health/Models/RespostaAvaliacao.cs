using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class RespostaAvaliacao
    {
        public int RespostaID { get; set; }
        public int Resposta { get; set; }
        public DateTime Data { get; set; }

        public Questao Questao { get; set; }
        public int QuestaoID { get; set; }

        public Turista Turista { get; set; }
        public int TuristaID { get; set; }

        public Guia Guia { get; set; }
        public int GuiaID { get; set; }
    }
}
