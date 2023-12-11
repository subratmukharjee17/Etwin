using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("Gantts", Schema = "ETwin")]
    public partial class Gantt
    {
        public Gantt()
        {
            ChangeLayouts = new HashSet<ChangeLayout>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string GanttName { get; set; }
        [StringLength(150)]
        public string GanttTitle { get; set; }
        [StringLength(150)]
        public string KeyFieldName { get; set; }
        [StringLength(150)]
        public string ParentFieldName { get; set; }
        [StringLength(150)]
        public string TextFieldName { get; set; }
        [StringLength(150)]
        public string StartDateFieldName { get; set; }
        [StringLength(150)]
        public string FinishDateFieldName { get; set; }
        [StringLength(150)]
        public string ProgressFieldName { get; set; }
        [StringLength(150)]
        public string PredecessorsFieldName { get; set; }
        public string SqlQueryDataSource { get; set; }

        [InverseProperty(nameof(ChangeLayout.IdGanttNavigation))]
        public virtual ICollection<ChangeLayout> ChangeLayouts { get; set; }
    }
}
