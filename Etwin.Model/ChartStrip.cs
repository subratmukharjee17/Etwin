using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ChartStrips", Schema = "ETwin")]
    public partial class ChartStrip
    {
        [Key]
        public int IdChartStrips { get; set; }
        public int? IdChartSerie { get; set; }
        [StringLength(100)]
        public string StripsName { get; set; }
        [StringLength(5)]
        public string Axis { get; set; }
        public string MaxLimit { get; set; }
        public string MinLimit { get; set; }
        public bool? ShowAxisLabel { get; set; }
        [StringLength(50)]
        public string AxisLabelText { get; set; }
        public bool? ShowInLegend { get; set; }
        [StringLength(50)]
        public string LegendText { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        public int? FillMode { get; set; }

        [ForeignKey(nameof(IdChartSerie))]
        [InverseProperty(nameof(ChartSeries.ChartStrips))]
        public virtual ChartSeries IdChartSerieNavigation { get; set; }
    }
}
