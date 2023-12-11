using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class WarehouseDocument
    {
        public WarehouseDocument()
        {
            WarehouseMovementDocuments = new HashSet<WarehouseMovementDocument>();
        }

        [Key]
        public int Id { get; set; }
        public int IdDocumentType { get; set; }
        [Required]
        [Column("WareHouseDocument")]
        public string WareHouseDocument1 { get; set; }

        [InverseProperty(nameof(WarehouseMovementDocument.IdDocumentNavigation))]
        public virtual ICollection<WarehouseMovementDocument> WarehouseMovementDocuments { get; set; }
    }
}
