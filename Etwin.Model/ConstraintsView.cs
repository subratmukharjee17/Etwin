using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ConstraintsView
    {
        public int IdPhaseConstraint { get; set; }
        public string ConstraintName { get; set; }
        public int IdInputWizard { get; set; }
        [Required]
        public string Title { get; set; }
        public int IdInputStepWizard { get; set; }
        [Required]
        public string TitleStep { get; set; }
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
    }
}
