using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class PurchaseOrderValue
    {
        [Key]
        public int Id { get; set; }
        public int IdPurchaseOrderRow { get; set; }
        public int IdPurchaseOrderParameter { get; set; }
        [StringLength(150)]
        public string Value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdPurchaseOrderRow))]
        [InverseProperty(nameof(PurchaseOrderRow.PurchaseOrderValues))]
        public virtual PurchaseOrderRow IdPurchaseOrderRowNavigation { get; set; }
    }
}
