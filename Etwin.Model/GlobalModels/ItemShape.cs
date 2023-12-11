using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class ItemShape
    {
        [Key]
        public int Id { get; set; }
        public int IdItemType { get; set; }
        [Required]
        public string Shape { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdItemType))]
        [InverseProperty(nameof(ItemType.ItemShapes))]
        public virtual ItemType IdItemTypeNavigation { get; set; }
    }
}
