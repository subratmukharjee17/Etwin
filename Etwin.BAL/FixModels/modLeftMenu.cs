using Etwin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modLeftMenu
    {
        public dynamic? LstData { get; set; }
        public string MenuType { get; set; }
        public IList<GridsColumn>? Columns { get; set; }
        public string contrlNme { get; set; }
    }
}
