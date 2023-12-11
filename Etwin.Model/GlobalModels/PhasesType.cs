using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("PhasesType")]
    public partial class PhasesType
    {
        public PhasesType()
        {
            Phases = new HashSet<Phase>();
        }

        [Key]
        public int IdPhaseType { get; set; }
        [StringLength(50)]
        public string PhaseType { get; set; }

        [InverseProperty(nameof(Phase.IdPhaseTypeNavigation))]
        public virtual ICollection<Phase> Phases { get; set; }
    }
}
