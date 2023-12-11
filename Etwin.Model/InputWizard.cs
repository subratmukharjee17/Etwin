using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("InputWizard")]
    public partial class InputWizard
    {
        public InputWizard()
        {
            InputStepWizards = new HashSet<InputStepWizard>();
            PhasesConstraints = new HashSet<PhasesConstraint>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [InverseProperty(nameof(InputStepWizard.IdCustomWizardNavigation))]
        public virtual ICollection<InputStepWizard> InputStepWizards { get; set; }
        [InverseProperty(nameof(PhasesConstraint.IdInputWizardNavigation))]
        public virtual ICollection<PhasesConstraint> PhasesConstraints { get; set; }
    }
}
