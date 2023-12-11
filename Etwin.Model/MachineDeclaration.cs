using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class MachineDeclaration
    {
        public MachineDeclaration()
        {
            MachineDeclarationValues = new HashSet<MachineDeclarationValue>();
        }

        [Key]
        public int IdMachineDeclaration { get; set; }
        public int IdMachine { get; set; }
        public int IdPhaseCompany { get; set; }
        public int IdProcessList { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DeclarationDate { get; set; }
        public int IdPhaseState { get; set; }
        public int? IdMachineTimestep { get; set; }

        [ForeignKey(nameof(IdMachine))]
        [InverseProperty(nameof(Machine.MachineDeclarations))]
        public virtual Machine IdMachineNavigation { get; set; }
        [ForeignKey(nameof(IdPhaseCompany))]
        [InverseProperty(nameof(PhasesCompany.MachineDeclarations))]
        public virtual PhasesCompany IdPhaseCompanyNavigation { get; set; }
        [ForeignKey(nameof(IdProcessList))]
        [InverseProperty(nameof(ProcessesList.MachineDeclarations))]
        public virtual ProcessesList IdProcessListNavigation { get; set; }
        [InverseProperty(nameof(MachineDeclarationValue.IdMachineDeclarationNavigation))]
        public virtual ICollection<MachineDeclarationValue> MachineDeclarationValues { get; set; }
    }
}
