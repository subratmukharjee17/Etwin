using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("BomType")]
    public partial class BomType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
    }
}
