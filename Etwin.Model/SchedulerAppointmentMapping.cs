using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("SchedulerAppointmentMapping", Schema = "ETwin")]
    public partial class SchedulerAppointmentMapping
    {
        [Key]
        public int IdAppointmentMapping { get; set; }
        public int IdScheduler { get; set; }
        [StringLength(100)]
        public string AllDay { get; set; }
        [StringLength(100)]
        public string AppointmentId { get; set; }
        [StringLength(100)]
        public string StartAppointment { get; set; }
        [StringLength(100)]
        public string EndAppointment { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Label { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        [StringLength(100)]
        public string OriginalOccurenceStart { get; set; }
        [StringLength(100)]
        public string OriginalOccurenceEnd { get; set; }
        [StringLength(50)]
        public string PercentComplete { get; set; }
        [StringLength(50)]
        public string ResourceId { get; set; }
        [StringLength(50)]
        public string TimeZoneId { get; set; }
        public int? AppointmentType { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(50)]
        public string StatusKey { get; set; }
        [StringLength(50)]
        public string ReminderInfo { get; set; }
        [StringLength(50)]
        public string RecurrenceInfo { get; set; }
        public string QueryDatasource { get; set; }
        public bool? ResourceSharing { get; set; }

        [ForeignKey(nameof(IdScheduler))]
        [InverseProperty(nameof(Scheduler.SchedulerAppointmentMappings))]
        public virtual Scheduler IdSchedulerNavigation { get; set; }
    }
}
