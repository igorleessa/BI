
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIWebServices.BI.FaturamentoIVEL
{
    public class FatoFaturamentoIVELWO
    {
        public string Operacao { get; set; }
        public string AnoMes { get; set; }
        public float ValorNF { get; set; }
        public bool TradeMarketing { get; set; }
        public string CodHex { get; set; }
    }
}