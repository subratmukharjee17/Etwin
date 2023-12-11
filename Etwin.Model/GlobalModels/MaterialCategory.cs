using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class MaterialCategory
    {
        public MaterialCategory()
        {
            MaterialSubCategories = new HashSet<MaterialSubCategory>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(MaterialSubCategory.IdMaterialCategoriesNavigation))]
        public virtual ICollection<MaterialSubCategory> MaterialSubCategories { get; set; }
    }
}
