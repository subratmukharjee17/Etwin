using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewProcessi
    {
        [Required]
        [StringLength(50)]
        public string Process { get; set; }
        [Required]
        [StringLength(15)]
        public string Order { get; set; }
        [Required]
        [StringLength(50)]
        public string Phase { get; set; }
        [Required]
        [StringLength(50)]
        public string ProcessPhase { get; set; }
        [StringLength(50)]
        public string PhaseTypeDescription { get; set; }
        public int? ProcessPhaseOrder { get; set; }
    }
}
