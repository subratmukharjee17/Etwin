using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class ProposalOrder
    {
        public ProposalOrder()
        {
            WarehouseMovements = new HashSet<WarehouseMovement>();
        }

        [Key]
        public int Id { get; set; }
        public int IdProposalType { get; set; }
        public int IdProposalState { get; set; }
        public int IdWarehouseItem { get; set; }
        public int Quantity { get; set; }
        public int IdMeasureUnit { get; set; }
        public int? IdSupplier { get; set; }
        [StringLength(400)]
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProposalDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdSupplier))]
        [InverseProperty(nameof(Supplier.ProposalOrders))]
        public virtual Supplier IdSupplierNavigation { get; set; }
        [ForeignKey(nameof(IdWarehouseItem))]
        [InverseProperty(nameof(WarehouseItem.ProposalOrders))]
        public virtual WarehouseItem IdWarehouseItemNavigation { get; set; }
        [InverseProperty(nameof(WarehouseMovement.IdProposalNavigation))]
        public virtual ICollection<WarehouseMovement> WarehouseMovements { get; set; }
    }
}
