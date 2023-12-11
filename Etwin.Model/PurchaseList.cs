using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class PurchaseList
    {
        [Key]
        public int Id { get; set; }
        public int IdSupplier { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ValidationStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ValidationEndDate { get; set; }
        public int IdItem { get; set; }
        public int IdMeasureUnit { get; set; }
        public int? MaxQty { get; set; }
        public int? MinQty { get; set; }
        public int? DayApproxDeliveryDate { get; set; }
        public double? UnitPrice { get; set; }
        public int? IdCurrency { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.PurchaseLists))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdSupplier))]
        [InverseProperty(nameof(Supplier.PurchaseLists))]
        public virtual Supplier IdSupplierNavigation { get; set; }
    }
}
