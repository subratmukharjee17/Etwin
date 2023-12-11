using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class AnalysisDrawing
    {
        [Key]
        public int Id { get; set; }
        public byte[] ByteOfFile { get; set; }
        [Required]
        public string ConnectionString { get; set; }
        public int IdDrawingState { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string Path { get; set; }
        public int? IdMainDrawing { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdDrawingState))]
        [InverseProperty(nameof(DrawingState.AnalysisDrawings))]
        public virtual DrawingState IdDrawingStateNavigation { get; set; }
    }
}
