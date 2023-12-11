using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("MaterialCode")]
    public partial class MaterialCode
    {
        public MaterialCode()
        {
            MaterialCodeValues = new HashSet<MaterialCodeValue>();
            MaterialStandards = new HashSet<MaterialStandard>();
        }

        [Key]
        public int Id { get; set; }
        public int IdSubCategory { get; set; }
        [Required]
        public string Code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdSubCategory))]
        [InverseProperty(nameof(MaterialSubCategory.MaterialCodes))]
        public virtual MaterialSubCategory IdSubCategoryNavigation { get; set; }
        [InverseProperty(nameof(MaterialCodeValue.IdMaterialCodeNavigation))]
        public virtual ICollection<MaterialCodeValue> MaterialCodeValues { get; set; }
        [InverseProperty(nameof(MaterialStandard.IdMaterialCodeNavigation))]
        public virtual ICollection<MaterialStandard> MaterialStandards { get; set; }
    }
}
