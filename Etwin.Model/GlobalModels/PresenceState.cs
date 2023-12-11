using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class PresenceState
    {
        [Key]
        public int IdPresenceState { get; set; }
        [Required]
        [Column("PresenceState")]
        [StringLength(50)]
        public string PresenceState1 { get; set; }
    }
}
