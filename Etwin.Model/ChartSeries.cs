using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ChartSeries", Schema = "ETwin")]
    public partial class ChartSeries
    {
        public ChartSeries()
        {
            ChartConstantLines = new HashSet<ChartConstantLine>();
            ChartStrips = new HashSet<ChartStrip>();
            RangeClients = new HashSet<RangeClient>();
        }

        [Key]
        public int Id { get; set; }
        public int IdChart { get; set; }
        public int IdChartSeriesType { get; set; }
        [Required]
        [StringLength(150)]
        public string SeriesDataMember { get; set; }
        public int? ArgumentScaletype { get; set; }
        [Required]
        [StringLength(150)]
        public string ArgumentDataMember { get; set; }
        public int? ValueScaleType { get; set; }
        [Required]
        [StringLength(150)]
        public string ValueDataMember { get; set; }
        [Required]
        [StringLength(150)]
        public string TextPattern { get; set; }
        [StringLength(150)]
        public string LegendTextPattern { get; set; }
        public int Ordine { get; set; }
        [Required]
        public bool? ShowLabels { get; set; }
        public string SqlQuery { get; set; }
        public string LabelTextPattern { get; set; }
        public string ColorSerie { get; set; }

        [ForeignKey(nameof(IdChart))]
        [InverseProperty(nameof(Chart.ChartSeries))]
        public virtual Chart IdChartNavigation { get; set; }
        [InverseProperty(nameof(ChartConstantLine.IdChartSerieNavigation))]
        public virtual ICollection<ChartConstantLine> ChartConstantLines { get; set; }
        [InverseProperty(nameof(ChartStrip.IdChartSerieNavigation))]
        public virtual ICollection<ChartStrip> ChartStrips { get; set; }
        [InverseProperty(nameof(RangeClient.IdChartSeriesNavigation))]
        public virtual ICollection<RangeClient> RangeClients { get; set; }
    }
}
