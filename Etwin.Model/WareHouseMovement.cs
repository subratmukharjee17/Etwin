using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class WarehouseMovement
    {
        public WarehouseMovement()
        {
            WarehouseMovementDocuments = new HashSet<WarehouseMovementDocument>();
        }

        [Key]
        public int Id { get; set; }
        public int? IdOrderRow { get; set; }
        public int? IdProposal { get; set; }
        public int IdWareHouseItem { get; set; }
        public int IdWareHouseMovementType { get; set; }
        public int IdWarehouse { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime MovementDate { get; set; }
        public int? Quantity { get; set; }

        [ForeignKey(nameof(IdOrderRow))]
        [InverseProperty(nameof(OrderRow.WarehouseMovements))]
        public virtual OrderRow IdOrderRowNavigation { get; set; }
        [ForeignKey(nameof(IdProposal))]
        [InverseProperty(nameof(ProposalOrder.WarehouseMovements))]
        public virtual ProposalOrder IdProposalNavigation { get; set; }
        [ForeignKey(nameof(IdWareHouseItem))]
        [InverseProperty(nameof(WarehouseItem.WarehouseMovements))]
        public virtual WarehouseItem IdWareHouseItemNavigation { get; set; }
        [InverseProperty(nameof(WarehouseMovementDocument.IdWareHouseMovementNavigation))]
        public virtual ICollection<WarehouseMovementDocument> WarehouseMovementDocuments { get; set; }
    }
}
