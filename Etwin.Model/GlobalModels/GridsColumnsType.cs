using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("GridsColumnsType", Schema = "ETwin")]
    public partial class GridsColumnsType
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Valore { get; set; }
        [StringLength(256)]
        public string Descrizione { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCreazione { get; set; }
    }
}
