using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class OperatorRole
    {
        [Key]
        public int IdOperatorRole { get; set; }
        [Required]
        [Column("OperatorRole")]
        [StringLength(10)]
        public string OperatorRole1 { get; set; }
        [Required]
        [StringLength(50)]
        public string DescriptionRole { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
    }
}
