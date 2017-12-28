﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class TipoResposta
    {
        public int TipoRespostaID { get; set; }
        public int TipoR { get; set; }
        public string Descricao { get; set; }
        
        public ICollection<Questao> Questoes { get; set; }
    }
}
