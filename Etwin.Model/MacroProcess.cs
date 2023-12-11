using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class MacroProcess
    {
        public MacroProcess()
        {
            PhasesSequences = new HashSet<PhasesSequence>();
            ProcessesLists = new HashSet<ProcessesList>();
        }

        [Key]
        public int IdMacroProcess { get; set; }
        [StringLength(10)]
        public string MacroProcessCode { get; set; }
        public string MacroProcessDescription { get; set; }
        public int? Enabled { get; set; }
        public int? Priority { get; set; }
        public string Condition { get; set; }
        public int? ProcessSequence { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
        public bool? IsGeneric { get; set; }
        public int IdDepartment { get; set; }

        [InverseProperty(nameof(PhasesSequence.IdMacroProcessesNavigation))]
        public virtual ICollection<PhasesSequence> PhasesSequences { get; set; }
        [InverseProperty(nameof(ProcessesList.IdMacroProcessNavigation))]
        public virtual ICollection<ProcessesList> ProcessesLists { get; set; }
    }
}
