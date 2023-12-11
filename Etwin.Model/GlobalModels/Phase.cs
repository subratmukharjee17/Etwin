using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class Phase
    {
        public Phase()
        {
            PhasesItemParameters = new HashSet<PhasesItemParameter>();
            WebTags = new HashSet<WebTag>();
        }

        [Key]
        public int IdPhase { get; set; }
        public int IdDepartment { get; set; }
        public int IdPhaseType { get; set; }
        [StringLength(15)]
        public string PhaseCode { get; set; }
        [Required]
        [Column("Phase")]
        [StringLength(50)]
        public string Phase1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdDepartment))]
        [InverseProperty(nameof(Department.Phases))]
        public virtual Department IdDepartmentNavigation { get; set; }
        [ForeignKey(nameof(IdPhaseType))]
        [InverseProperty(nameof(PhasesType.Phases))]
        public virtual PhasesType IdPhaseTypeNavigation { get; set; }
        [InverseProperty(nameof(PhasesItemParameter.IdPhaseNavigation))]
        public virtual ICollection<PhasesItemParameter> PhasesItemParameters { get; set; }
        [InverseProperty(nameof(WebTag.IdPhaseNavigation))]
        public virtual ICollection<WebTag> WebTags { get; set; }
    }
}
