using Etwin.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etwin.DAL.Models
{
    public class SchedularViewModel
    {
        public IList<SchedulerAppointmentMapping> ClsschedulerAppointmentMapping { get; set; }
        public IList<SchedulerResourceMapping> ClsschedulerResourceMapping { get; set; }


    }
}
