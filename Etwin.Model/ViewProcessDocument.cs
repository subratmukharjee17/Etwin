using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewProcessDocument
    {
        public int IdOrder { get; set; }
        public int IdProject { get; set; }
        public int IdOrderType { get; set; }
        public int IdOrderStates { get; set; }
        public int IdCustomer { get; set; }
        [Required]
        [StringLength(15)]
        public string Order { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
    }
}
