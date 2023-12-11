using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("PlannerOutput", Schema = "etwindb")]
    public partial class PlannerOutput
    {
        [Key]
        public int IdDeclaration { get; set; }
        public int? IdProcessList { get; set; }
        [StringLength(50)]
        public string Matricola { get; set; }
        [StringLength(50)]
        public string Fase { get; set; }
        public int? DeclarationDate { get; set; }
        public int? IdPhaseActivity { get; set; }
        public int? ProducedQty { get; set; }
        [StringLength(10)]
        public string IdPhaseState { get; set; }
    }
}
