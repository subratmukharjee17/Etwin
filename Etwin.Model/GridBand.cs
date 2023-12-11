using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("GridBands", Schema = "ETwin")]
    public partial class GridBand
    {
        public GridBand()
        {
            GridsColumns = new HashSet<GridsColumn>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int IdGrid { get; set; }
        [Required]
        [StringLength(150)]
        public string BandName { get; set; }
        [Required]
        [StringLength(150)]
        public string Caption { get; set; }
        [StringLength(1024)]
        public string ToolTip { get; set; }
        [StringLength(150)]
        public string FontName { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? FontSize { get; set; }
        public bool? FontBold { get; set; }
        public int BandOrder { get; set; }
        public int? BandFixed { get; set; }

        [ForeignKey(nameof(IdGrid))]
        [InverseProperty(nameof(Grid.GridBands))]
        public virtual Grid IdGr { get; set; }
        [InverseProperty(nameof(GridsColumn.IdBandNavigation))]
        public virtual ICollection<GridsColumn> GridsColumns { get; set; }
    }
}
