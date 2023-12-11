using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modDeclarationWithPhase 
    {
        public int RankPK { get; set; }
        public int IdDeclaration { get; set; }
        public int IdProcessList { get; set; }
        public string OperatorCode { get; set; }
        public int IdPhase { get; set; }
        public string PhaseCode { get; set; }
        public DateTime DeclarationDate { get; set; }
        public int IdTimestep { get; set; }
        public int IdNf { get; set; }
        public int IdModule { get; set; }
        public int IdPhaseActivity { get; set; }
        public string ProducedQty { get; set; }
        public int IdPhaseState { get; set; }
        public bool IsFuture { get; set; }

    }
}
