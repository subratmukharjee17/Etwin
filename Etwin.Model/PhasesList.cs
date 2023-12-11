using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("PhasesList")]
    public partial class PhasesList
    {
        public PhasesList()
        {
            BomPhases = new HashSet<BomPhase>();
        }

        [Key]
        public int IdPhaseList { get; set; }
        public int IdProcessList { get; set; }
        public int IdPhaseCompany { get; set; }
        public int? MaxOperatorLimit { get; set; }
        public int? MinOperatorLimit { get; set; }
        public double? EstimatedOperatorTime { get; set; }
        public int? EstimatedMachinetime { get; set; }
        public int? IdMachineGroup { get; set; }
        public bool? ExternalPhases { get; set; }
        [StringLength(50)]
        public string ModifierUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifierDate { get; set; }
        public int? IdPhaseListState { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastStateChange { get; set; }

        [ForeignKey(nameof(IdMachineGroup))]
        [InverseProperty(nameof(MachineGroup.PhasesLists))]
        public virtual MachineGroup IdMachineGroupNavigation { get; set; }
        [ForeignKey(nameof(IdPhaseCompany))]
        [InverseProperty(nameof(PhasesCompany.PhasesLists))]
        public virtual PhasesCompany IdPhaseCompanyNavigation { get; set; }
        [ForeignKey(nameof(IdProcessList))]
        [InverseProperty(nameof(ProcessesList.PhasesLists))]
        public virtual ProcessesList IdProcessListNavigation { get; set; }
        [InverseProperty(nameof(BomPhase.IdPhaseListNavigation))]
        public virtual ICollection<BomPhase> BomPhases { get; set; }
    }
}
