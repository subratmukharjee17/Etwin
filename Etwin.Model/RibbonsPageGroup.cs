using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("RibbonsPageGroups", Schema = "ETwin")]
    public partial class RibbonsPageGroup
    {
        [Key]
        public int Id { get; set; }
        public int IdRibbonPage { get; set; }
        [Required]
        [StringLength(50)]
        public string RibbonPageGroupName { get; set; }
        [Required]
        [StringLength(50)]
        public string RibbonPageGroupTitle { get; set; }
        public int Ordine { get; set; }

        [ForeignKey(nameof(IdRibbonPage))]
        [InverseProperty(nameof(RibbonsPage.RibbonsPageGroups))]
        public virtual RibbonsPage IdRibbonPageNavigation { get; set; }
    }
}
