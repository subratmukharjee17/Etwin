using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("Grids", Schema = "ETwin")]
    public partial class Grid
    {
        public Grid()
        {
            ChangeLayouts = new HashSet<ChangeLayout>();
            GridBands = new HashSet<GridBand>();
            InverseIdgridParentNavigation = new HashSet<Grid>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDGridParent")]
        public int? IdgridParent { get; set; }
        [StringLength(150)]
        public string RelationKey { get; set; }
        [Required]
        [StringLength(150)]
        public string GridName { get; set; }
        [Required]
        [StringLength(150)]
        public string Caption { get; set; }
        [StringLength(150)]
        public string FontName { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? FontSize { get; set; }
        public bool? FontBold { get; set; }
        public bool Export { get; set; }
        public string SqlQuery { get; set; }
        public int? Ordine { get; set; }
        public bool CheckBox { get; set; }
        public bool? AllowDragDrop { get; set; }
        [StringLength(50)]
        public string ReferenceTableModel { get; set; }
        public bool? TreeList { get; set; }

        [ForeignKey(nameof(IdgridParent))]
        [InverseProperty(nameof(Grid.InverseIdgridParentNavigation))]
        public virtual Grid IdgridParentNavigation { get; set; }
        [InverseProperty(nameof(ChangeLayout.IdGr))]
        public virtual ICollection<ChangeLayout> ChangeLayouts { get; set; }
        [InverseProperty(nameof(GridBand.IdGr))]
        public virtual ICollection<GridBand> GridBands { get; set; }
        [InverseProperty(nameof(Grid.IdgridParentNavigation))]
        public virtual ICollection<Grid> InverseIdgridParentNavigation { get; set; }
    }
}
