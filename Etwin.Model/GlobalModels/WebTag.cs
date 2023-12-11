using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class WebTag
    {
        [Key]
        public int IdWebTag { get; set; }
        public int IdPhase { get; set; }
        [Required]
        [Column("WebTag")]
        [StringLength(50)]
        public string WebTag1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdPhase))]
        [InverseProperty(nameof(Phase.WebTags))]
        public virtual Phase IdPhaseNavigation { get; set; }
    }
}
