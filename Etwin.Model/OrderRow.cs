using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class OrderRow
    {
        public OrderRow()
        {
            OrderValues = new HashSet<OrderValue>();
            ProcessesLists = new HashSet<ProcessesList>();
            SalesPrices = new HashSet<SalesPrice>();
            Tracks = new HashSet<Track>();
            WarehouseMovements = new HashSet<WarehouseMovement>();
        }

        [Key]
        public int IdOrderRow { get; set; }
        public int? IdOrderParent { get; set; }
        public int IdOrderType { get; set; }
        public int IdOrderStates { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdItem { get; set; }
        [Column("OrderRow")]
        public int OrderRow1 { get; set; }
        [StringLength(400)]
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }
        public int? Rank { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdCustomer))]
        [InverseProperty(nameof(Customer.OrderRows))]
        public virtual Customer IdCustomerNavigation { get; set; }
        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.OrderRows))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdOrderParent))]
        [InverseProperty(nameof(Order.OrderRows))]
        public virtual Order IdOrderParentNavigation { get; set; }
        [InverseProperty(nameof(OrderValue.IdOrderRowNavigation))]
        public virtual ICollection<OrderValue> OrderValues { get; set; }
        [InverseProperty(nameof(ProcessesList.IdOrderRowNavigation))]
        public virtual ICollection<ProcessesList> ProcessesLists { get; set; }
        [InverseProperty(nameof(SalesPrice.IdOrderRowNavigation))]
        public virtual ICollection<SalesPrice> SalesPrices { get; set; }
        [InverseProperty(nameof(Track.IdOrderRowNavigation))]
        public virtual ICollection<Track> Tracks { get; set; }
        [InverseProperty(nameof(WarehouseMovement.IdOrderRowNavigation))]
        public virtual ICollection<WarehouseMovement> WarehouseMovements { get; set; }
    }
}
