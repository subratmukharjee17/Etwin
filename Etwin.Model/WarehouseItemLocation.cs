using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class WarehouseItemLocation
    {
        public WarehouseItemLocation()
        {
            WarehouseItems = new HashSet<WarehouseItem>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Location { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(WarehouseItem.IdLocationNavigation))]
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
    }
}
