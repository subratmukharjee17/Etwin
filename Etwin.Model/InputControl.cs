using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("InputControl")]
    public partial class InputControl
    {
        public InputControl()
        {
            InputCompilationIdInputControlNavigations = new HashSet<InputCompilation>();
            InputCompilationIdInputControlToCompleteNavigations = new HashSet<InputCompilation>();
        }

        [Key]
        public int Id { get; set; }
        public int IdCustomStepWizard { get; set; }
        [Required]
        public string DatabaseTable { get; set; }
        [Required]
        public string TableColumn { get; set; }
        public int? IdPvt { get; set; }
        [Required]
        public string ColumnText { get; set; }
        public int IdColumnValueType { get; set; }
        public int IdControlType { get; set; }
        public int? Length { get; set; }
        public int Sequences { get; set; }
        public string EffectiveValue { get; set; }
        public string Autocomplete { get; set; }
        public string Datasource { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? Visible { get; set; }
        public bool Required { get; set; }
        public bool IsUnique { get; set; }

        [ForeignKey(nameof(IdCustomStepWizard))]
        [InverseProperty(nameof(InputStepWizard.InputControls))]
        public virtual InputStepWizard IdCustomStepWizardNavigation { get; set; }
        [InverseProperty(nameof(InputCompilation.IdInputControlNavigation))]
        public virtual ICollection<InputCompilation> InputCompilationIdInputControlNavigations { get; set; }
        [InverseProperty(nameof(InputCompilation.IdInputControlToCompleteNavigation))]
        public virtual ICollection<InputCompilation> InputCompilationIdInputControlToCompleteNavigations { get; set; }
    }
}
