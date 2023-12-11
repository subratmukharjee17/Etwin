using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class ConstraintType
    {
        [Key]
        public int IdConstraintType { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
