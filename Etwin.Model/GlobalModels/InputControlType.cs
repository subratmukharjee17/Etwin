using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("InputControlType")]
    public partial class InputControlType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ControlType { get; set; }
    }
}
