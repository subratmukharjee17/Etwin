using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewOperatoriPresenze
    {
        [Required]
        [StringLength(15)]
        public string OperatorCode { get; set; }
        [StringLength(15)]
        public string BadgeCode { get; set; }
        public int IdDeclaration { get; set; }
        public int? IdProcessList { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
    }
}
