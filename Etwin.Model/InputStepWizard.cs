using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("InputStepWizard")]
    public partial class InputStepWizard
    {
        public InputStepWizard()
        {
            InputControls = new HashSet<InputControl>();
        }

        [Key]
        public int Id { get; set; }
        public int IdCustomWizard { get; set; }
        [Required]
        public string TitleStep { get; set; }
        public int Sequence { get; set; }

        [ForeignKey(nameof(IdCustomWizard))]
        [InverseProperty(nameof(InputWizard.InputStepWizards))]
        public virtual InputWizard IdCustomWizardNavigation { get; set; }
        [InverseProperty(nameof(InputControl.IdCustomStepWizardNavigation))]
        public virtual ICollection<InputControl> InputControls { get; set; }
    }
}
