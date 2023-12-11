using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("GridsColumns", Schema = "ETwin")]
    public partial class GridsColumn
    {
        public GridsColumn()
        {
            GridTooltips = new HashSet<GridTooltip>();
        }

        [Key]
        public int Id { get; set; }
        public int IdBand { get; set; }
        [Required]
        [StringLength(50)]
        public string ColumnText { get; set; }
        [StringLength(1024)]
        public string ColumnTooltip { get; set; }
        [Required]
        [StringLength(50)]
        public string ColumnName { get; set; }
        [StringLength(50)]
        public string FontName { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? FontSize { get; set; }
        public bool? FontBold { get; set; }
        public int IdColumnType { get; set; }
        public string FunctionName { get; set; }
        public int ColumnOrder { get; set; }
        [Required]
        [StringLength(50)]
        public string BackColor { get; set; }
        [Required]
        [StringLength(50)]
        public string ForeColor { get; set; }
        public bool Vertical { get; set; }
        [Required]
        public bool? AllowGroup { get; set; }
        public bool Alert { get; set; }
        public bool Editabile { get; set; }
        public int? MinWidth { get; set; }
        public bool? MergeCell { get; set; }
        public string QueryTypeCombo { get; set; }

        [ForeignKey(nameof(IdBand))]
        [InverseProperty(nameof(GridBand.GridsColumns))]
        public virtual GridBand IdBandNavigation { get; set; }
        [InverseProperty(nameof(GridTooltip.IdGridColumnNavigation))]
        public virtual ICollection<GridTooltip> GridTooltips { get; set; }
    }
}
