using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class WarehouseMovementDocument
    {
        [Key]
        public int Id { get; set; }
        public int IdWareHouseMovement { get; set; }
        public int IdDocument { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdDocument))]
        [InverseProperty(nameof(WarehouseDocument.WarehouseMovementDocuments))]
        public virtual WarehouseDocument IdDocumentNavigation { get; set; }
        [ForeignKey(nameof(IdWareHouseMovement))]
        [InverseProperty(nameof(WarehouseMovement.WarehouseMovementDocuments))]
        public virtual WarehouseMovement IdWareHouseMovementNavigation { get; set; }
    }
}
