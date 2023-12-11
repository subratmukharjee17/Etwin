using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class MovementType
    {
        public MovementType()
        {
            WarehouseMovementTypes = new HashSet<WarehouseMovementType>();
        }

        [Key]
        public int IdMovementType { get; set; }
        public string Movement { get; set; }

        [InverseProperty(nameof(WarehouseMovementType.IdMovementTypeNavigation))]
        public virtual ICollection<WarehouseMovementType> WarehouseMovementTypes { get; set; }
    }
}
