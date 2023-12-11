using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class MaterialSubCategory
    {
        public MaterialSubCategory()
        {
            MaterialCodes = new HashSet<MaterialCode>();
            MaterialSubCategoriesValues = new HashSet<MaterialSubCategoriesValue>();
        }

        [Key]
        public int Id { get; set; }
        public int IdMaterialCategories { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descriptions { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdMaterialCategories))]
        [InverseProperty(nameof(MaterialCategory.MaterialSubCategories))]
        public virtual MaterialCategory IdMaterialCategoriesNavigation { get; set; }
        [InverseProperty(nameof(MaterialCode.IdSubCategoryNavigation))]
        public virtual ICollection<MaterialCode> MaterialCodes { get; set; }
        [InverseProperty(nameof(MaterialSubCategoriesValue.IdMaterialSubCategoriesNavigation))]
        public virtual ICollection<MaterialSubCategoriesValue> MaterialSubCategoriesValues { get; set; }
    }
}
