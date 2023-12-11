using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewWareHouseStatus
    {
        [Required]
        public string PartNumber { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(512)]
        public string Description { get; set; }
        [StringLength(5)]
        public string Measure { get; set; }
        public int? Quantity { get; set; }
        [StringLength(256)]
        public string WareHouse { get; set; }
        [Required]
        [StringLength(256)]
        public string Location { get; set; }
        [StringLength(50)]
        public string Department { get; set; }
        [StringLength(65)]
        public string Supplier { get; set; }
    }
}
