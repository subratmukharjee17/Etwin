using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("OperatorsEngine", Schema = "etwindb")]
    public partial class OperatorsEngine
    {
        public OperatorsEngine()
        {
            KcfPlanners = new HashSet<KcfPlanner>();
        }

        [Key]
        [StringLength(15)]
        public string Matricola { get; set; }
        public string NameSurname { get; set; }
        public int Id { get; set; }

        [InverseProperty(nameof(KcfPlanner.OperatorCodeNavigation))]
        public virtual ICollection<KcfPlanner> KcfPlanners { get; set; }
    }
}
