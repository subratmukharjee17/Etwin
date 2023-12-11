using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("MeasureUnitGroup")]
    public partial class MeasureUnitGroup
    {
        [Key]
        public int IdMeasureUnitGroup { get; set; }
        [StringLength(100)]
        public string GroupName { get; set; }
    }
}
