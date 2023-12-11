using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ChartAxisTitles", Schema = "ETwin")]
    public partial class ChartAxisTitle
    {
        public ChartAxisTitle()
        {
            Charts = new HashSet<Chart>();
        }

        [Key]
        public int IdAxisTitle { get; set; }
        [Column("XText")]
        public string Xtext { get; set; }
        [Column("XFont")]
        public string Xfont { get; set; }
        [Column("XFontStyle")]
        public int? XfontStyle { get; set; }
        [Column("XFontSize")]
        public int? XfontSize { get; set; }
        [Column("XColor")]
        public string Xcolor { get; set; }
        [Column("XAlignment")]
        public int? Xalignment { get; set; }
        [Column("YText")]
        public string Ytext { get; set; }
        [Column("YFont")]
        public string Yfont { get; set; }
        [Column("YFontStyle")]
        public int? YfontStyle { get; set; }
        [Column("YFontSize")]
        public int? YfontSize { get; set; }
        [Column("YColor")]
        public string Ycolor { get; set; }
        [Column("YAlignment")]
        public int? Yalignment { get; set; }

        [InverseProperty(nameof(Chart.IdAxisTitleNavigation))]
        public virtual ICollection<Chart> Charts { get; set; }
    }
}
