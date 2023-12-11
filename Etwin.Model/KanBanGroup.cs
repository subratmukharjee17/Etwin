using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("KanBanGroup", Schema = "ETwin")]
    public partial class KanBanGroup
    {
        public KanBanGroup()
        {
            KanBanItems = new HashSet<KanBanItem>();
        }

        [Key]
        public int Id { get; set; }
        public int IdBoard { get; set; }
        [Required]
        public string Caption { get; set; }
        public string FooterText { get; set; }
        public string Font { get; set; }
        public int? FontStyle { get; set; }
        public int? FontSize { get; set; }
        public bool AllowDrag { get; set; }
        public string Status { get; set; }
        public bool? AutomaticGenerate { get; set; }

        [ForeignKey(nameof(IdBoard))]
        [InverseProperty(nameof(KanBanBoard.KanBanGroups))]
        public virtual KanBanBoard IdBoardNavigation { get; set; }
        [InverseProperty(nameof(KanBanItem.IdGroupNavigation))]
        public virtual ICollection<KanBanItem> KanBanItems { get; set; }
    }
}
