using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("GridTooltip", Schema = "ETwin")]
    public partial class GridTooltip
    {
        [Key]
        public int Id { get; set; }
        public int IdGridColumn { get; set; }
        [Required]
        public string Name { get; set; }
        public string Text { get; set; }
        public string Font { get; set; }
        public int? FontStyle { get; set; }
        public int? FontSize { get; set; }
        public int? TextAlignment { get; set; }
        public string Image { get; set; }
        public int? ImageAlignment { get; set; }
        public bool IsQuery { get; set; }
        public int Order { get; set; }
        public bool SeparatorLine { get; set; }

        [ForeignKey(nameof(IdGridColumn))]
        [InverseProperty(nameof(GridsColumn.GridTooltips))]
        public virtual GridsColumn IdGridColumnNavigation { get; set; }
    }
}
