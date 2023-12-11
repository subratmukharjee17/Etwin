using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modTimeSteps
    {
        public string Operatore { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Scheda { get; set; }
        public string Ordine { get; set; }
        public string NF { get; set; }
        public string Attivita { get; set; }
        public string Fase { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataEnd { get; set; }
        public TimeSpan DurataStep { get; set; }
        public TimeSpan DurataFase { get; set; }
        public TimeSpan DurataCommessa { get; set; }
    }
}
