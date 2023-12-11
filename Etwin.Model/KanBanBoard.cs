using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("KanBanBoard", Schema = "ETwin")]
    public partial class KanBanBoard
    {
        public KanBanBoard()
        {
            KanBanGroups = new HashSet<KanBanGroup>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool? AutoHeight { get; set; }
        public int? Alignment { get; set; }
        public string Query { get; set; }

        [InverseProperty(nameof(KanBanGroup.IdBoardNavigation))]
        public virtual ICollection<KanBanGroup> KanBanGroups { get; set; }
    }
}
