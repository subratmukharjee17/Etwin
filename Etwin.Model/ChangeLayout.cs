using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ChangeLayout")]
    public partial class ChangeLayout
    {
        [Key]
        public int IdOpenStatusBarForm { get; set; }
        public int? IdGrid { get; set; }
        public int? IdChart { get; set; }
        public int? IdScheduler { get; set; }
        public int? IdGantt { get; set; }

        [ForeignKey(nameof(IdChart))]
        [InverseProperty(nameof(Chart.ChangeLayouts))]
        public virtual Chart IdChartNavigation { get; set; }
        [ForeignKey(nameof(IdGantt))]
        [InverseProperty(nameof(Gantt.ChangeLayouts))]
        public virtual Gantt IdGanttNavigation { get; set; }
        [ForeignKey(nameof(IdGrid))]
        [InverseProperty(nameof(Grid.ChangeLayouts))]
        public virtual Grid IdGr { get; set; }
        [ForeignKey(nameof(IdScheduler))]
        [InverseProperty(nameof(Scheduler.ChangeLayouts))]
        public virtual Scheduler IdSchedulerNavigation { get; set; }
    }
}
