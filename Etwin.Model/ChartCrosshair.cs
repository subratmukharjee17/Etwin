using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ChartCrosshair", Schema = "ETwin")]
    public partial class ChartCrosshair
    {
        [Key]
        public int Id { get; set; }
        public int IdChart { get; set; }
        [Required]
        public string CrossHairLabelName { get; set; }
        public string LabelBackColor { get; set; }
        public int? LabelMode { get; set; }
        public bool ShowArgumentLine { get; set; }
        public bool ShowValueLine { get; set; }
        public string ArgumentLineColor { get; set; }
        public string ValueLineColor { get; set; }
        [Column("ALineStyle")]
        public int? AlineStyle { get; set; }
        [Column("VLineStyle")]
        public int? VlineStyle { get; set; }
        public string HeaderFont { get; set; }
        public int? HeaderFontStyle { get; set; }
        public int? HeaderFontSize { get; set; }
        public string HeaderForeColor { get; set; }
        public string CrossHairFont { get; set; }
        public int? CrossHairFontStyle { get; set; }
        public int? CrosshairFontSize { get; set; }
        public string CrossHairForeColor { get; set; }
        [Column("ALineThickness")]
        public int? AlineThickness { get; set; }
        [Column("VLineThickness")]
        public int? VlineThickness { get; set; }

        [ForeignKey(nameof(IdChart))]
        [InverseProperty(nameof(Chart.ChartCrosshairs))]
        public virtual Chart IdChartNavigation { get; set; }
    }
}
