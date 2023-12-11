using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderRows = new HashSet<PurchaseOrderRow>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("NPurchaseOrder")]
        [StringLength(15)]
        public string NpurchaseOrder { get; set; }
        [StringLength(400)]
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(PurchaseOrderRow.IdPurchaseOrderParentNavigation))]
        public virtual ICollection<PurchaseOrderRow> PurchaseOrderRows { get; set; }
    }
}
