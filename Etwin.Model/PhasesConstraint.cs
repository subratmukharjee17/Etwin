using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class PhasesConstraint
    {
        public PhasesConstraint()
        {
            ConstraintConditions = new HashSet<ConstraintCondition>();
        }

        [Key]
        public int IdPhaseConstraint { get; set; }
        [StringLength(10)]
        public string ConstraintCode { get; set; }
        public int? IdPhaseCompany { get; set; }
        public string ConstraintName { get; set; }
        public int? Sorting { get; set; }
        public int? IdPhaseState { get; set; }
        public int? IdConstraintType { get; set; }
        public int? IdInputWizard { get; set; }
        public string ConditionAfterInput { get; set; }
        public int? IdEventWhenTrue { get; set; }
        public int? IdEventWhenFalse { get; set; }

        [ForeignKey(nameof(IdInputWizard))]
        [InverseProperty(nameof(InputWizard.PhasesConstraints))]
        public virtual InputWizard IdInputWizardNavigation { get; set; }
        [ForeignKey(nameof(IdPhaseCompany))]
        [InverseProperty(nameof(PhasesCompany.PhasesConstraints))]
        public virtual PhasesCompany IdPhaseCompanyNavigation { get; set; }
        [InverseProperty(nameof(ConstraintCondition.IdPhaseConstraintNavigation))]
        public virtual ICollection<ConstraintCondition> ConstraintConditions { get; set; }
    }
}
