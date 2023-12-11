using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("ItemWorking")]
    public partial class ItemWorking
    {
        [Key]
        public int Id { get; set; }
        public int IdItemType { get; set; }
        [Required]
        public string Working { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdItemType))]
        [InverseProperty(nameof(ItemType.ItemWorkings))]
        public virtual ItemType IdItemTypeNavigation { get; set; }
    }
}
