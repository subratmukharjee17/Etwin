using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modItemParameterGlobal
    {
        public int IdItemParameter { get; set; }
        public string ItemParameterName { get; set; }
        public string ItemParameterDescription { get; set; }
        public int IdItemType { get; set; }
        public int IdDataType { get; set; }
        public string Calculation { get; set; }
        public int ExecutionOrder { get; set; }
        public bool IsFilter { get; set; }
        public string FilterCommand { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
