using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Timestep
    {
        [Key]
        public int IdTimestep { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartStep { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndStep { get; set; }
        public int? PeriodStep { get; set; }
    }
}
