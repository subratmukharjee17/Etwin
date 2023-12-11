using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("Events", Schema = "ETwin")]
    public partial class Event
    {
        public Event()
        {
            EventLogs = new HashSet<EventLog>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        public int ExecPeriodInMinutes { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string ParameterQuery { get; set; }
        public string ProcedureName { get; set; }
        public int? Order { get; set; }

        [InverseProperty(nameof(EventLog.IdEventNavigation))]
        public virtual ICollection<EventLog> EventLogs { get; set; }
    }
}
