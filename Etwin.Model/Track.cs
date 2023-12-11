using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("Track")]
    public partial class Track
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Track")]
        public string Track1 { get; set; }
        public int IdOrderRow { get; set; }
        public int IdItem { get; set; }
        public int? Refernce { get; set; }
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.Tracks))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdOrderRow))]
        [InverseProperty(nameof(OrderRow.Tracks))]
        public virtual OrderRow IdOrderRowNavigation { get; set; }
    }
}
