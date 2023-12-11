using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class ConstraintCondition
    {
        [Key]
        public int IdConstraintCondition { get; set; }
        [Required]
        public string QueryCondition { get; set; }
        public int IdPhaseConstraint { get; set; }

        [ForeignKey(nameof(IdPhaseConstraint))]
        [InverseProperty(nameof(PhasesConstraint.ConstraintConditions))]
        public virtual PhasesConstraint IdPhaseConstraintNavigation { get; set; }
    }
}
