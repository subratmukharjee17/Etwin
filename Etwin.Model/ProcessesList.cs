using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ProcessesList")]
    public partial class ProcessesList
    {
        public ProcessesList()
        {
            Assignments = new HashSet<Assignment>();
            Declarations = new HashSet<Declaration>();
            DeclarationsFutures = new HashSet<DeclarationsFuture>();
            MachineDeclarations = new HashSet<MachineDeclaration>();
            PhasesLists = new HashSet<PhasesList>();
        }

        [Key]
        public int IdProcessList { get; set; }
        public int? IdOrderRow { get; set; }
        public int? IdMacroProcess { get; set; }
        public int? IdItem { get; set; }
        [StringLength(50)]
        public string ProcessCode { get; set; }
        [StringLength(50)]
        public string ModifierUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifierDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifyDate { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.ProcessesLists))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdMacroProcess))]
        [InverseProperty(nameof(MacroProcess.ProcessesLists))]
        public virtual MacroProcess IdMacroProcessNavigation { get; set; }
        [ForeignKey(nameof(IdOrderRow))]
        [InverseProperty(nameof(OrderRow.ProcessesLists))]
        public virtual OrderRow IdOrderRowNavigation { get; set; }
        [InverseProperty(nameof(Assignment.IdProcessListNavigation))]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [InverseProperty(nameof(Declaration.IdProcessListNavigation))]
        public virtual ICollection<Declaration> Declarations { get; set; }
        [InverseProperty(nameof(DeclarationsFuture.IdProcessListNavigation))]
        public virtual ICollection<DeclarationsFuture> DeclarationsFutures { get; set; }
        [InverseProperty(nameof(MachineDeclaration.IdProcessListNavigation))]
        public virtual ICollection<MachineDeclaration> MachineDeclarations { get; set; }
        [InverseProperty(nameof(PhasesList.IdProcessListNavigation))]
        public virtual ICollection<PhasesList> PhasesLists { get; set; }
    }
}
