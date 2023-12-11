using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class OperatorActiveState
    {
        [Key]
        public int IdOperatorActiveState { get; set; }
        [Required]
        [Column("OperatorActiveState")]
        [StringLength(15)]
        public string OperatorActiveState1 { get; set; }
    }
}
