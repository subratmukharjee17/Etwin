using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("RibbonsPageGroupButtons", Schema = "ETwin")]
    public partial class RibbonsPageGroupButton
    {
        [Key]
        public int Id { get; set; }
        public int IdRibbonPageGroup { get; set; }
        [Required]
        [StringLength(50)]
        public string RibbonPageGroupButtonName { get; set; }
        [Required]
        [StringLength(50)]
        public string RibbonPageGroupButtonTitle { get; set; }
        [StringLength(150)]
        public string RibbonPageGroupButtonImage { get; set; }
        public int? IdControl { get; set; }
        public int? IdControlType { get; set; }
        public int ButtonOrder { get; set; }
    }
}
