using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("MeasureUnit")]
    public partial class MeasureUnit
    {
        [Key]
        public int IdMeasureUnit { get; set; }
        [StringLength(10)]
        public string Measure { get; set; }
        [StringLength(50)]
        public string MeasureName { get; set; }
        public int? IdMeasureGroup { get; set; }
    }
}
