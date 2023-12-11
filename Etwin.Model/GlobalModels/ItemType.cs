using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("ItemType")]
    public partial class ItemType
    {
        public ItemType()
        {
            InverseIdTypeParentNavigation = new HashSet<ItemType>();
            ItemParameters = new HashSet<ItemParameter>();
            ItemShapes = new HashSet<ItemShape>();
            ItemWorkings = new HashSet<ItemWorking>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public int? IdTypeParent { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdTypeParent))]
        [InverseProperty(nameof(ItemType.InverseIdTypeParentNavigation))]
        public virtual ItemType IdTypeParentNavigation { get; set; }
        [InverseProperty(nameof(ItemType.IdTypeParentNavigation))]
        public virtual ICollection<ItemType> InverseIdTypeParentNavigation { get; set; }
        [InverseProperty(nameof(ItemParameter.IdItemTypeNavigation))]
        public virtual ICollection<ItemParameter> ItemParameters { get; set; }
        [InverseProperty(nameof(ItemShape.IdItemTypeNavigation))]
        public virtual ICollection<ItemShape> ItemShapes { get; set; }
        [InverseProperty(nameof(ItemWorking.IdItemTypeNavigation))]
        public virtual ICollection<ItemWorking> ItemWorkings { get; set; }
    }
}
