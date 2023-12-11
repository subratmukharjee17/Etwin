using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class DrawingState
    {
        public DrawingState()
        {
            AnalysisDrawings = new HashSet<AnalysisDrawing>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string State { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(AnalysisDrawing.IdDrawingStateNavigation))]
        public virtual ICollection<AnalysisDrawing> AnalysisDrawings { get; set; }
    }
}
