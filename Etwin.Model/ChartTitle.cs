using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ChartTitle", Schema = "ETwin")]
    public partial class ChartTitle
    {
        [Key]
        public int IdChartTitle { get; set; }
        public int IdChart { get; set; }
        [Required]
        public string TextTitle { get; set; }
        public string Font { get; set; }
        public int? FontStyle { get; set; }
        public int? FontSize { get; set; }
        public string TextColor { get; set; }
        public int? Alignment { get; set; }

        [ForeignKey(nameof(IdChart))]
        [InverseProperty(nameof(Chart.ChartTitles))]
        public virtual Chart IdChartNavigation { get; set; }
    }
}
