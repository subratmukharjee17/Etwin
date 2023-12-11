using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("MaterialStandard")]
    public partial class MaterialStandard
    {
        [Key]
        public int Id { get; set; }
        public int IdMaterialCode { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdMaterialCode))]
        [InverseProperty(nameof(MaterialCode.MaterialStandards))]
        public virtual MaterialCode IdMaterialCodeNavigation { get; set; }
    }
}
