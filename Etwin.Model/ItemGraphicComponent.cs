using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class ItemGraphicComponent
    {
        [Key]
        public int Id { get; set; }
        public int IdItem { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Value { get; set; }
        public int? IdMeasureUnit { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.ItemGraphicComponents))]
        public virtual Item IdItemNavigation { get; set; }
    }
}
