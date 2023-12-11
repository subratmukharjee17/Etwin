using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("EventLog", Schema = "ETwin")]
    public partial class EventLog
    {
        [Key]
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public int IdEventState { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(IdEvent))]
        [InverseProperty(nameof(Event.EventLogs))]
        public virtual Event IdEventNavigation { get; set; }
    }
}
