using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("MachineGroup")]
    public partial class MachineGroup
    {
        public MachineGroup()
        {
            Machines = new HashSet<Machine>();
            PhasesLists = new HashSet<PhasesList>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(Machine.IdMachineGroupNavigation))]
        public virtual ICollection<Machine> Machines { get; set; }
        [InverseProperty(nameof(PhasesList.IdMachineGroupNavigation))]
        public virtual ICollection<PhasesList> PhasesLists { get; set; }
    }
}
