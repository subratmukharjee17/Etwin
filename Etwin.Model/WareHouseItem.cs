using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class WarehouseItem
    {
        public WarehouseItem()
        {
            ProposalOrders = new HashSet<ProposalOrder>();
            WarehouseMovements = new HashSet<WarehouseMovement>();
        }

        [Key]
        public int Id { get; set; }
        public int IdWareHouse { get; set; }
        public int? IdLocation { get; set; }
        public int? IdProvenance { get; set; }
        public int? IdMeasureUnit { get; set; }
        public int IdItem { get; set; }
        public double? MinQuantity { get; set; }
        public double? MaxQuantity { get; set; }
        public double? CurrentQuantity { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.WarehouseItems))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdLocation))]
        [InverseProperty(nameof(WarehouseItemLocation.WarehouseItems))]
        public virtual WarehouseItemLocation IdLocationNavigation { get; set; }
        [InverseProperty(nameof(ProposalOrder.IdWarehouseItemNavigation))]
        public virtual ICollection<ProposalOrder> ProposalOrders { get; set; }
        [InverseProperty(nameof(WarehouseMovement.IdWareHouseItemNavigation))]
        public virtual ICollection<WarehouseMovement> WarehouseMovements { get; set; }
    }
}
