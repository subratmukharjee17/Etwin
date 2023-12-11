using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("OrderType")]
    public partial class OrderType
    {
        [Key]
        public int IdOrderType { get; set; }
        [Required]
        [StringLength(15)]
        public string Value { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
    }
}
