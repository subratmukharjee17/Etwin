using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("Charts", Schema = "ETwin")]
    public partial class Chart
    {
        public Chart()
        {
            ChangeLayouts = new HashSet<ChangeLayout>();
            ChartAnimations = new HashSet<ChartAnimation>();
            ChartCrosshairs = new HashSet<ChartCrosshair>();
            ChartPanes = new HashSet<ChartPane>();
            ChartSeries = new HashSet<ChartSeries>();
            ChartTitles = new HashSet<ChartTitle>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string ChartName { get; set; }
        public int? IdAxisTitle { get; set; }
        [Required]
        public bool? ShowLegend { get; set; }
        public int? LegendMarkerMode { get; set; }
        public string ColorDataMember { get; set; }
        public string TagDataMember { get; set; }
        public int? Height { get; set; }
        public int? IdRadar { get; set; }

        [ForeignKey(nameof(IdAxisTitle))]
        [InverseProperty(nameof(ChartAxisTitle.Charts))]
        public virtual ChartAxisTitle IdAxisTitleNavigation { get; set; }
        [InverseProperty(nameof(ChangeLayout.IdChartNavigation))]
        public virtual ICollection<ChangeLayout> ChangeLayouts { get; set; }
        [InverseProperty(nameof(ChartAnimation.IdChartNavigation))]
        public virtual ICollection<ChartAnimation> ChartAnimations { get; set; }
        [InverseProperty(nameof(ChartCrosshair.IdChartNavigation))]
        public virtual ICollection<ChartCrosshair> ChartCrosshairs { get; set; }
        [InverseProperty(nameof(ChartPane.IdChartNavigation))]
        public virtual ICollection<ChartPane> ChartPanes { get; set; }
        [InverseProperty("IdChartNavigation")]
        public virtual ICollection<ChartSeries> ChartSeries { get; set; }
        [InverseProperty(nameof(ChartTitle.IdChartNavigation))]
        public virtual ICollection<ChartTitle> ChartTitles { get; set; }
    }
}
