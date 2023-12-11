using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modPhaseProducible
    {
        public int IdBom { get; set; }
        public int IdPhase { get; set; }
        public int IdBomParent { get; set; }
    }
}
