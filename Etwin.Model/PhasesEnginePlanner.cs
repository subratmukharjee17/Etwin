using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("PhasesEnginePlanner", Schema = "etwindb")]
    public partial class PhasesEnginePlanner
    {
        [Key]
        public int IdPhaseList { get; set; }
        public int? IdOrderRow { get; set; }
        public int? Priority { get; set; }
        public string DeliveryDate { get; set; }
        public int? IdPhase { get; set; }
        public string PhaseCode { get; set; }
        public string PhaseName { get; set; }
        public int? PhaseSequence { get; set; }
        public int? ProcessSequence { get; set; }
        public string EstimatedOperatorTime { get; set; }
        public bool? Producibile { get; set; }
        public string ProducibileDa { get; set; }
    }
}
