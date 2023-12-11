using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("KcfPlanner", Schema = "etwindb")]
    public partial class KcfPlanner
    {
        [Key]
        public int IdKcf { get; set; }
        [Required]
        [StringLength(15)]
        public string OperatorCode { get; set; }
        public int IdPhase { get; set; }
        public int? Kcf { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(OperatorCode))]
        [InverseProperty(nameof(OperatorsEngine.KcfPlanners))]
        public virtual OperatorsEngine OperatorCodeNavigation { get; set; }
    }
}
