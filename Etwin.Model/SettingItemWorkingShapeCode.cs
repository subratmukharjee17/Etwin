using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class SettingItemWorkingShapeCode
    {
        [Key]
        public int IdSettingWorkingShape { get; set; }
        public int IdItemWorking { get; set; }
        public int IdItemShape { get; set; }
        [Required]
        [StringLength(5)]
        public string Code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
    }
}
