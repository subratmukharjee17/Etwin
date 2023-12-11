using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("KpiParameters", Schema = "ETwin")]
    public partial class KpiParameter
    {
        [Key]
        public int Id { get; set; }
        public int IdKpi { get; set; }
        [Required]
        public string ParameterName { get; set; }
        [Required]
        public string Query { get; set; }

        [ForeignKey(nameof(IdKpi))]
        [InverseProperty(nameof(Kpi.KpiParameters))]
        public virtual Kpi IdKpiNavigation { get; set; }
    }
}
