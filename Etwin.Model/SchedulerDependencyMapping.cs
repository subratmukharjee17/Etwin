using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("SchedulerDependencyMappings", Schema = "ETwin")]
    public partial class SchedulerDependencyMapping
    {
        [Key]
        public int IdDependecyMapping { get; set; }
        public int? IdScheduler { get; set; }
        [StringLength(50)]
        public string DependentId { get; set; }
        [StringLength(50)]
        public string ParentId { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        public string QueryDatasource { get; set; }

        [ForeignKey(nameof(IdScheduler))]
        [InverseProperty(nameof(Scheduler.SchedulerDependencyMappings))]
        public virtual Scheduler IdSchedulerNavigation { get; set; }
    }
}
