using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class WarehouseProvenance
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Provenance { get; set; }
    }
}
