using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class OrderValue
    {
        [Key]
        public int IdOrderValues { get; set; }
        public int IdOrderRow { get; set; }
        public int IdOrderParameter { get; set; }
        [StringLength(150)]
        public string Value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdOrderRow))]
        [InverseProperty(nameof(OrderRow.OrderValues))]
        public virtual OrderRow IdOrderRowNavigation { get; set; }
    }
}
