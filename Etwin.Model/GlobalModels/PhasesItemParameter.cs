using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class PhasesItemParameter
    {
        [Key]
        public int Id { get; set; }
        public int IdPhase { get; set; }
        public int IdItemParameter { get; set; }

        [ForeignKey(nameof(IdItemParameter))]
        [InverseProperty(nameof(ItemParameter.PhasesItemParameters))]
        public virtual ItemParameter IdItemParameterNavigation { get; set; }
        [ForeignKey(nameof(IdPhase))]
        [InverseProperty(nameof(Phase.PhasesItemParameters))]
        public virtual Phase IdPhaseNavigation { get; set; }
    }
}
