using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("Kpi", Schema = "ETwin")]
    public partial class Kpi
    {
        public Kpi()
        {
            KpiParameters = new HashSet<KpiParameter>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string KpiName { get; set; }
        public int? KpiLimit { get; set; }
        public int? KpiGradient { get; set; }
        public string Operation { get; set; }
        public string Query { get; set; }
        [Required]
        public string Timespan { get; set; }
        public string MinData { get; set; }
        public string MaxData { get; set; }

        [InverseProperty(nameof(KpiParameter.IdKpiNavigation))]
        public virtual ICollection<KpiParameter> KpiParameters { get; set; }
    }
}
