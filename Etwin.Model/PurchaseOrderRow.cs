using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class PurchaseOrderRow
    {
        public PurchaseOrderRow()
        {
            PurchaseOrderValues = new HashSet<PurchaseOrderValue>();
        }

        [Key]
        public int IdPurchaseOrderRow { get; set; }
        public int? IdPurchaseOrderParent { get; set; }
        public int IdOrderType { get; set; }
        public int IdOrderStates { get; set; }
        public int? IdItem { get; set; }
        public int? IdSupplier { get; set; }
        public int? IdCurrency { get; set; }
        [Column("PurchaseOrderRow")]
        public int? PurchaseOrderRow1 { get; set; }
        public double? Price { get; set; }
        [StringLength(400)]
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.PurchaseOrderRows))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdPurchaseOrderParent))]
        [InverseProperty(nameof(PurchaseOrder.PurchaseOrderRows))]
        public virtual PurchaseOrder IdPurchaseOrderParentNavigation { get; set; }
        [ForeignKey(nameof(IdSupplier))]
        [InverseProperty(nameof(Supplier.PurchaseOrderRows))]
        public virtual Supplier IdSupplierNavigation { get; set; }
        [InverseProperty(nameof(PurchaseOrderValue.IdPurchaseOrderRowNavigation))]
        public virtual ICollection<PurchaseOrderValue> PurchaseOrderValues { get; set; }
    }
}
