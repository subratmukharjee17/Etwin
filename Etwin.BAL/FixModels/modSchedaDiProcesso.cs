using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modSchedaDiProcesso
    {
        public int? IdModulo { get; set; }
        public string Cliente { get; set; }
        public string Protocollo { get; set; }
        public string? NumeroOrdine { get; set; }
        public string? Modello { get; set; }
        public string Revisione { get; set; }
        public string Disegno { get; set; }
        public string? NoteOrdine { get; set; }
        public int QuantitaOrdine { get; set; }
        public string NomeFase { get; set; }
        public int NumeroOperatori { get; set; }
        public int? Tempo { get; set; }
        public string? NoteFase { get; set; }
    }
}
