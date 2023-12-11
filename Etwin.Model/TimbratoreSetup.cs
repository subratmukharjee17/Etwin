using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("TimbratoreSetup", Schema = "ETwin")]
    public partial class TimbratoreSetup
    {
        public TimbratoreSetup()
        {
            InverseIdParentNavigation = new HashSet<TimbratoreSetup>();
        }

        [Key]
        public int IdTimbratoreSetup { get; set; }
        public int? IdParent { get; set; }
        [StringLength(100)]
        public string PageName { get; set; }
        [StringLength(100)]
        public string Caption { get; set; }
        [StringLength(50)]
        public string FontName { get; set; }
        public int? FontSize { get; set; }
        public bool? FontBold { get; set; }
        public string SqlQuery { get; set; }
        public string Condition { get; set; }
        public int? ControlMargin { get; set; }
        public double? ControlSize { get; set; }
        public bool IsLastLevel { get; set; }

        [ForeignKey(nameof(IdParent))]
        [InverseProperty(nameof(TimbratoreSetup.InverseIdParentNavigation))]
        public virtual TimbratoreSetup IdParentNavigation { get; set; }
        [InverseProperty(nameof(TimbratoreSetup.IdParentNavigation))]
        public virtual ICollection<TimbratoreSetup> InverseIdParentNavigation { get; set; }
    }
}
