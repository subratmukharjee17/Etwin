using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modAppointment
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Predecessors { get; set; }
    }
}
