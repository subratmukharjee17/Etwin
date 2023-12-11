using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class WareHouseLocation
    {
        public WareHouseLocation()
        {
            WareHouseItems = new HashSet<WarehouseItem>();
        }

        [Key]
        public int Id { get; set; }
        public int? IdWareHouse { get; set; }
        [Required]
        [StringLength(256)]
        public string Location { get; set; }
        public string Description { get; set; }

        [InverseProperty(nameof(WarehouseItem.IdLocationNavigation))]
        public virtual ICollection<WarehouseItem> WareHouseItems { get; set; }
    }
}
