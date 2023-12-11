using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class WarehouseMovementType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Movement { get; set; }
        [Required]
        public string Description { get; set; }
        public int? IdMovementType { get; set; }

        [ForeignKey(nameof(IdMovementType))]
        [InverseProperty(nameof(MovementType.WarehouseMovementTypes))]
        public virtual MovementType IdMovementTypeNavigation { get; set; }
    }
}
