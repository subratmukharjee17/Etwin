using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            ProposalOrders = new HashSet<ProposalOrder>();
            PurchaseLists = new HashSet<PurchaseList>();
            PurchaseOrderRows = new HashSet<PurchaseOrderRow>();
        }

        [Key]
        public int Id { get; set; }
        public int? SupplierIdentityCode { get; set; }
        [StringLength(50)]
        public string BusinessName { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Cap { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string Province { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string TelephoneNumber { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string VatNumber { get; set; }
        [StringLength(50)]
        public string FiscalCode { get; set; }
        public string Note { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(ProposalOrder.IdSupplierNavigation))]
        public virtual ICollection<ProposalOrder> ProposalOrders { get; set; }
        [InverseProperty(nameof(PurchaseList.IdSupplierNavigation))]
        public virtual ICollection<PurchaseList> PurchaseLists { get; set; }
        [InverseProperty(nameof(PurchaseOrderRow.IdSupplierNavigation))]
        public virtual ICollection<PurchaseOrderRow> PurchaseOrderRows { get; set; }
    }
}
