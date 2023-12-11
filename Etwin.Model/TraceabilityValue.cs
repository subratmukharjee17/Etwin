using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("TraceabilityValue")]
    public partial class TraceabilityValue
    {
        [Key]
        public int Id { get; set; }
        public int IdTraceability { get; set; }
        public int IdTraceabilityParameter { get; set; }
        [Required]
        public string Value { get; set; }
        public int? Sequence { get; set; }
    }
}
