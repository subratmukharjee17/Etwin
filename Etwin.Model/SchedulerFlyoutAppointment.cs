using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("SchedulerFlyoutAppointment", Schema = "ETwin")]
    public partial class SchedulerFlyoutAppointment
    {
        [Key]
        public int Id { get; set; }
        public int IdScheduler { get; set; }
        public bool ShowReminder { get; set; }
        public bool ShowLocation { get; set; }
        public bool ShowEndDate { get; set; }
        public bool ShowStartDate { get; set; }
        public bool ShowStatus { get; set; }
        public string BackColor { get; set; }
        public string Font { get; set; }
        public int? FontStyle { get; set; }
        public int? FontSize { get; set; }
        public string ForeColor { get; set; }

        [ForeignKey(nameof(IdScheduler))]
        [InverseProperty(nameof(Scheduler.SchedulerFlyoutAppointments))]
        public virtual Scheduler IdSchedulerNavigation { get; set; }
    }
}
