using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("RibbonsPages", Schema = "ETwin")]
    public partial class RibbonsPage
    {
        public RibbonsPage()
        {
            RibbonsPageGroups = new HashSet<RibbonsPageGroup>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string RibbonPageName { get; set; }
        [Required]
        [StringLength(50)]
        public string RibbonPageTitle { get; set; }
        [StringLength(150)]
        public string RibbonPageImage { get; set; }
        public int Ordine { get; set; }
        public int? IdDepartment { get; set; }

        [InverseProperty(nameof(RibbonsPageGroup.IdRibbonPageNavigation))]
        public virtual ICollection<RibbonsPageGroup> RibbonsPageGroups { get; set; }
    }
}
