using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("Schedulers", Schema = "ETwin")]
    public partial class Scheduler
    {
        public Scheduler()
        {
            ChangeLayouts = new HashSet<ChangeLayout>();
            SchedulerAppointmentMappings = new HashSet<SchedulerAppointmentMapping>();
            SchedulerDependencyMappings = new HashSet<SchedulerDependencyMapping>();
            SchedulerFlyoutAppointments = new HashSet<SchedulerFlyoutAppointment>();
            SchedulerResourceMappings = new HashSet<SchedulerResourceMapping>();
        }

        [Key]
        public int Id { get; set; }
        public int IdSchedulerType { get; set; }
        [Required]
        [StringLength(150)]
        public string SchedulerName { get; set; }
        [StringLength(150)]
        public string SchedulerTitle { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SqlQueryAppointments { get; set; }
        public string CurrentDate { get; set; }

        [InverseProperty(nameof(ChangeLayout.IdSchedulerNavigation))]
        public virtual ICollection<ChangeLayout> ChangeLayouts { get; set; }
        [InverseProperty(nameof(SchedulerAppointmentMapping.IdSchedulerNavigation))]
        public virtual ICollection<SchedulerAppointmentMapping> SchedulerAppointmentMappings { get; set; }
        [InverseProperty(nameof(SchedulerDependencyMapping.IdSchedulerNavigation))]
        public virtual ICollection<SchedulerDependencyMapping> SchedulerDependencyMappings { get; set; }
        [InverseProperty(nameof(SchedulerFlyoutAppointment.IdSchedulerNavigation))]
        public virtual ICollection<SchedulerFlyoutAppointment> SchedulerFlyoutAppointments { get; set; }
        [InverseProperty(nameof(SchedulerResourceMapping.IdSchedulerNavigation))]
        public virtual ICollection<SchedulerResourceMapping> SchedulerResourceMappings { get; set; }
    }
}
