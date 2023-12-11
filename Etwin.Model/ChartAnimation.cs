using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ChartAnimations", Schema = "ETwin")]
    public partial class ChartAnimation
    {
        [Key]
        public int IdChartAnimation { get; set; }
        public int? IdChart { get; set; }
        public int? AnimationTime { get; set; }
        public int? Direction { get; set; }
        public int? BeginTime { get; set; }
        public int? PointDelay { get; set; }
        public int? PointOrder { get; set; }

        [ForeignKey(nameof(IdChart))]
        [InverseProperty(nameof(Chart.ChartAnimations))]
        public virtual Chart IdChartNavigation { get; set; }
    }
}
