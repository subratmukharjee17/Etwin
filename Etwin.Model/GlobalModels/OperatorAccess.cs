using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("OperatorAccess")]
    public partial class OperatorAccess
    {
        [Key]
        public int IdOperatorAccess { get; set; }
        [Required]
        public string AccessType { get; set; }
    }
}
