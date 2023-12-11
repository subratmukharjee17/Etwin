using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("Ped")]
    public partial class Ped
    {
        [Key]
        public int IdPed { get; set; }
        [StringLength(20)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
    }
}
