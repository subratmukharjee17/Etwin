using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("PhasesMachine")]
    public partial class PhasesMachine
    {
        [Key]
        public int Id { get; set; }
        public int IdPhaseCompany { get; set; }
        public int IdMachine { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdMachine))]
        [InverseProperty(nameof(Machine.PhasesMachines))]
        public virtual Machine IdMachineNavigation { get; set; }
        [ForeignKey(nameof(IdPhaseCompany))]
        [InverseProperty(nameof(PhasesCompany.PhasesMachines))]
        public virtual PhasesCompany IdPhaseCompanyNavigation { get; set; }
    }
}
