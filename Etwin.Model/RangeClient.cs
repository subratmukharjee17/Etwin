using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("RangeClient", Schema = "ETwin")]
    public partial class RangeClient
    {
        [Key]
        public int IdRangeClient { get; set; }
        public int? IdRange { get; set; }
        public int? IdChartSeries { get; set; }
        public int? IdAreaChartRange { get; set; }
        public string RangeMax { get; set; }
        public string RangeMin { get; set; }
        public string Datasource { get; set; }
        [StringLength(10)]
        public string LabelFormat { get; set; }
        public int? GridAlignment { get; set; }
        public int? SnapAlignment { get; set; }

        [ForeignKey(nameof(IdAreaChartRange))]
        [InverseProperty(nameof(RangeAreaChart.RangeClients))]
        public virtual RangeAreaChart IdAreaChartRangeNavigation { get; set; }
        [ForeignKey(nameof(IdChartSeries))]
        [InverseProperty(nameof(ChartSeries.RangeClients))]
        public virtual ChartSeries IdChartSeriesNavigation { get; set; }
        [ForeignKey(nameof(IdRange))]
        [InverseProperty(nameof(Range.RangeClients))]
        public virtual Range IdRangeNavigation { get; set; }
    }
}
