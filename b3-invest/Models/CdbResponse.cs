using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calculo_b3.Models
{
    public class CdbResponse
    {
        public double ValorBruto { get; set; }
        public double ValorLiquido { get; set; }
        public bool Erro {  get; set; }
        public string MsgErro { get; set; }
    }
}