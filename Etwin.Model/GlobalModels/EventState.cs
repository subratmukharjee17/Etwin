using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("EventState", Schema = "ETwin")]
    public partial class EventState
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Esito { get; set; }
    }
}
