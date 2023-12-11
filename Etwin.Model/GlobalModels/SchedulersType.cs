using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("SchedulersType", Schema = "ETwin")]
    public partial class SchedulersType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string SchedulerType { get; set; }
    }
}
