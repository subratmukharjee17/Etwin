using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class WorkingMode
    {
        [Key]
        public int IdWorkingMode { get; set; }
        [Column("WorkingMode")]
        public string WorkingMode1 { get; set; }
    }
}
