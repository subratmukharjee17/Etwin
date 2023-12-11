using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("ProgramVersion")]
    public partial class ProgramVersion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Version { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
    }
}
