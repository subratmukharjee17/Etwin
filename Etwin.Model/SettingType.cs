using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("SettingType")]
    public partial class SettingType
    {
        public SettingType()
        {
            ItemCodings = new HashSet<ItemCoding>();
            Items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }
        public int IdItemType { get; set; }
        [Required]
        [StringLength(1)]
        public string Code { get; set; }
        public int IdMeasureUnit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(ItemCoding.IdSettingTypeNavigation))]
        public virtual ICollection<ItemCoding> ItemCodings { get; set; }
        [InverseProperty(nameof(Item.IdSettingTypeNavigation))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
