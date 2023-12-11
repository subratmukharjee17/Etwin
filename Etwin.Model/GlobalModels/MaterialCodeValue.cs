using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("MaterialCodeValue")]
    public partial class MaterialCodeValue
    {
        [Key]
        public int Id { get; set; }
        public int IdMaterialCode { get; set; }
        [Required]
        public string Code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdMaterialCode))]
        [InverseProperty(nameof(MaterialCode.MaterialCodeValues))]
        public virtual MaterialCode IdMaterialCodeNavigation { get; set; }
    }
}
