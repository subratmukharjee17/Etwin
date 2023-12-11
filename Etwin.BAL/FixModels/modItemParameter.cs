using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modItemParameter
    {
        public string Name { get; set; }
        public string TipoParametro { get; set; }
        public string Value { get; set; }
        public string MeasureUnit { get; set; }
        [DefaultValue(false)]
        public bool IsVerified { get; set; }
        
    }
}
