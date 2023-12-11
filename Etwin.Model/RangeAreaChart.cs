using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("RangeAreaChart", Schema = "ETwin")]
    public partial class RangeAreaChart
    {
        public RangeAreaChart()
        {
            RangeClients = new HashSet<RangeClient>();
        }

        [Key]
        public int IdAreaChartRange { get; set; }
        public int? Opacity { get; set; }
        [StringLength(15)]
        public string AreaColor { get; set; }
        public int? MarkerSize { get; set; }
        [StringLength(15)]
        public string MarkerColor { get; set; }

        [InverseProperty(nameof(RangeClient.IdAreaChartRangeNavigation))]
        public virtual ICollection<RangeClient> RangeClients { get; set; }
    }
}
