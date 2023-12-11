using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("SchedulerResourceMapping", Schema = "ETwin")]
    public partial class SchedulerResourceMapping
    {
        [Key]
        public int IdResourceMapping { get; set; }
        public int IdScheduler { get; set; }
        [StringLength(50)]
        public string Caption { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        public string Image { get; set; }
        [StringLength(50)]
        public string ResourceId { get; set; }
        public string QueryDatasource { get; set; }

        [ForeignKey(nameof(IdScheduler))]
        [InverseProperty(nameof(Scheduler.SchedulerResourceMappings))]
        public virtual Scheduler IdSchedulerNavigation { get; set; }
    }
}
