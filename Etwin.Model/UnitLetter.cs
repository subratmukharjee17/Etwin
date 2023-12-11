using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class UnitLetter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(1)]
        public string Letter { get; set; }
        public int Unit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
    }
}
