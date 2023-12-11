using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewTimestepGrid
    {
        [Required]
        [StringLength(15)]
        public string OperatorCode { get; set; }
        [Required]
        [StringLength(50)]
        public string NameSurname { get; set; }
        [Required]
        [StringLength(50)]
        public string Phase { get; set; }
        [Required]
        [Column("NOrder")]
        [StringLength(15)]
        public string Norder { get; set; }
        public int? OrderRow { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartStep { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndStep { get; set; }
        public int? PeriodStep { get; set; }
    }
}
