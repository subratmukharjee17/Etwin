using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class PhasesSequence
    {
        [Key]
        public int IdPhaseSequence { get; set; }
        public int IdMacroProcesses { get; set; }
        public int? IdPhaseCompany { get; set; }
        public int? PhaseSequence { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [ForeignKey(nameof(IdMacroProcesses))]
        [InverseProperty(nameof(MacroProcess.PhasesSequences))]
        public virtual MacroProcess IdMacroProcessesNavigation { get; set; }
        [ForeignKey(nameof(IdPhaseCompany))]
        [InverseProperty(nameof(PhasesCompany.PhasesSequences))]
        public virtual PhasesCompany IdPhaseCompanyNavigation { get; set; }
    }
}
