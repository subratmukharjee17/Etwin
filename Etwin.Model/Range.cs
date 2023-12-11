using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("Range", Schema = "ETwin")]
    public partial class Range
    {
        public Range()
        {
            RangeClients = new HashSet<RangeClient>();
        }

        [Key]
        public int IdRange { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(RangeClient.IdRangeNavigation))]
        public virtual ICollection<RangeClient> RangeClients { get; set; }
    }
}
