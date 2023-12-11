using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modPhaseConstraints
    {
        //NOME DEL PARAMETRO DECLARATION
        public string ParameterName { get; set; }
        //CONDIZIONE DA VERIFICARE
        public string Condition { get; set; }
        //VALORE DEL PARAMETRO
        public string ParameterValue { get; set; }
    }
}
