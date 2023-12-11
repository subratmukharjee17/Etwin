using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ChartPanes", Schema = "ETwin")]
    public partial class ChartPane
    {
        [Key]
        public int Id { get; set; }
        public int IdChart { get; set; }
        [Required]
        [StringLength(150)]
        public string PaneName { get; set; }
        [StringLength(150)]
        public string PaneTitle { get; set; }

        [ForeignKey(nameof(IdChart))]
        [InverseProperty(nameof(Chart.ChartPanes))]
        public virtual Chart IdChartNavigation { get; set; }
    }
}
