using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderRows = new HashSet<OrderRow>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("NOrder")]
        [StringLength(50)]
        public string Norder { get; set; }
        [StringLength(400)]
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(OrderRow.IdOrderParentNavigation))]
        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}
