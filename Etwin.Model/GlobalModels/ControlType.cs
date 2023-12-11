using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("ControlType", Schema = "ETwin")]
    public partial class ControlType
    {
        [Key]
        public int IdType { get; set; }
        public string ControlName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
    }
}
