using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class BomPhase
    {
        [Key]
        public int Id { get; set; }
        public int IdPhaseList { get; set; }
        public int IdItem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.BomPhases))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdPhaseList))]
        [InverseProperty(nameof(PhasesList.BomPhases))]
        public virtual PhasesList IdPhaseListNavigation { get; set; }
    }
}
