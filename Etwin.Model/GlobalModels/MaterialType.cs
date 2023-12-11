using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("MaterialType")]
    public partial class MaterialType
    {
        [Key]
        public int IdMaterialType { get; set; }
        [StringLength(50)]
        public string MaterialCode { get; set; }
        public double? SpecificWeight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
    }
}
