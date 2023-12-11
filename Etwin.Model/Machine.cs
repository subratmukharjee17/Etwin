using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Machine
    {
        public Machine()
        {
            MachineDeclarations = new HashSet<MachineDeclaration>();
            PhasesMachines = new HashSet<PhasesMachine>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string MachineCode { get; set; }
        [Required]
        [StringLength(30)]
        public string Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Capacity { get; set; }
        [StringLength(400)]
        public string Note { get; set; }
        public int? IdMachineGroup { get; set; }
        public int? IdWorkingMode { get; set; }
        public int? IdProcessingMethod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public int? IdMachineStates { get; set; }

        [ForeignKey(nameof(IdMachineGroup))]
        [InverseProperty(nameof(MachineGroup.Machines))]
        public virtual MachineGroup IdMachineGroupNavigation { get; set; }
        [InverseProperty(nameof(MachineDeclaration.IdMachineNavigation))]
        public virtual ICollection<MachineDeclaration> MachineDeclarations { get; set; }
        [InverseProperty(nameof(PhasesMachine.IdMachineNavigation))]
        public virtual ICollection<PhasesMachine> PhasesMachines { get; set; }
    }
}
