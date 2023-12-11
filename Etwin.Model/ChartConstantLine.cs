using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ChartConstantLine", Schema = "ETwin")]
    public partial class ChartConstantLine
    {
        [Key]
        public int IdConstantLine { get; set; }
        public int? IdChartSerie { get; set; }
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        public int DashStyle { get; set; }
        public string FontFamily { get; set; }
        public int? FontSize { get; set; }
        public int Thickness { get; set; }
        public bool ShowBelowLine { get; set; }
        public string ColorLine { get; set; }
        public string ColorText { get; set; }
        public string Axis { get; set; }
        public int? Value { get; set; }

        [ForeignKey(nameof(IdChartSerie))]
        [InverseProperty(nameof(ChartSeries.ChartConstantLines))]
        public virtual ChartSeries IdChartSerieNavigation { get; set; }
    }
}
