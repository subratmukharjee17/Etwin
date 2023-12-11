using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modPhase
    {
        public int IdPhase { get; set; }
        public int IdDepartment { get; set; }
        public string PhaseCode { get; set; }
        public string Phase { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
