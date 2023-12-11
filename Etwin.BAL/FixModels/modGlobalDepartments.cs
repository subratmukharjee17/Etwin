using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modGlobalDepartments
    {
        public int IdDepartment { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string IconName { get; set; }
    }
}
