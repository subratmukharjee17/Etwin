using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class MaterialSubCategoriesValue
    {
        [Key]
        public int Id { get; set; }
        public int IdMaterialSubCategories { get; set; }
        [Required]
        public string Value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdMaterialSubCategories))]
        [InverseProperty(nameof(MaterialSubCategory.MaterialSubCategoriesValues))]
        public virtual MaterialSubCategory IdMaterialSubCategoriesNavigation { get; set; }
    }
}
