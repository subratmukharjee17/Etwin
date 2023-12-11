using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("PhasesCompany")]
    public partial class PhasesCompany
    {
        public PhasesCompany()
        {
            Assignments = new HashSet<Assignment>();
            Declarations = new HashSet<Declaration>();
            DeclarationsFutures = new HashSet<DeclarationsFuture>();
            MachineDeclarations = new HashSet<MachineDeclaration>();
            PhasesConstraints = new HashSet<PhasesConstraint>();
            PhasesLists = new HashSet<PhasesList>();
            PhasesMachines = new HashSet<PhasesMachine>();
            PhasesSequences = new HashSet<PhasesSequence>();
        }

        [Key]
        public int Id { get; set; }
        public int IdPhase { get; set; }
        [StringLength(15)]
        public string PhaseCode { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(Assignment.IdPhaseCompanyNavigation))]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [InverseProperty(nameof(Declaration.IdPhaseCompanyNavigation))]
        public virtual ICollection<Declaration> Declarations { get; set; }
        [InverseProperty(nameof(DeclarationsFuture.IdPhaseCompanyNavigation))]
        public virtual ICollection<DeclarationsFuture> DeclarationsFutures { get; set; }
        [InverseProperty(nameof(MachineDeclaration.IdPhaseCompanyNavigation))]
        public virtual ICollection<MachineDeclaration> MachineDeclarations { get; set; }
        [InverseProperty(nameof(PhasesConstraint.IdPhaseCompanyNavigation))]
        public virtual ICollection<PhasesConstraint> PhasesConstraints { get; set; }
        [InverseProperty(nameof(PhasesList.IdPhaseCompanyNavigation))]
        public virtual ICollection<PhasesList> PhasesLists { get; set; }
        [InverseProperty(nameof(PhasesMachine.IdPhaseCompanyNavigation))]
        public virtual ICollection<PhasesMachine> PhasesMachines { get; set; }
        [InverseProperty(nameof(PhasesSequence.IdPhaseCompanyNavigation))]
        public virtual ICollection<PhasesSequence> PhasesSequences { get; set; }
    }
}
