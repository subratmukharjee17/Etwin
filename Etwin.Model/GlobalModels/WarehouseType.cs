using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class WarehouseType
    {
        public WarehouseType()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        [Key]
        public int Id { get; set; }
        [Column("WarehouseType")]
        public string WarehouseType1 { get; set; }

        [InverseProperty(nameof(Warehouse.IdWareHouseTypeNavigation))]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
