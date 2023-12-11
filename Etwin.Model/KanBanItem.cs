using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("KanBanItem", Schema = "ETwin")]
    public partial class KanBanItem
    {
        [Key]
        public int Id { get; set; }
        public int IdGroup { get; set; }
        [Required]
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [ForeignKey(nameof(IdGroup))]
        [InverseProperty(nameof(KanBanGroup.KanBanItems))]
        public virtual KanBanGroup IdGroupNavigation { get; set; }
    }
}
