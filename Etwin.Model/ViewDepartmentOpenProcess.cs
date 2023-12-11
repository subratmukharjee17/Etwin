using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewDepartmentOpenProcess
    {
        public int IdDepartment { get; set; }
        [StringLength(2)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int IdPhaseType { get; set; }
        [StringLength(15)]
        public string PhaseCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Phase { get; set; }
        public int IdPhaseList { get; set; }
        public int IdProcessList { get; set; }
        public int? MaxOperatorLimit { get; set; }
        public int? MinOperatorLimit { get; set; }
        public double? EstimatedOperatorTime { get; set; }
        public int? EstimatedMachinetime { get; set; }
        public int? IdMachineGroup { get; set; }
        public string ModifierUser { get; set; }
        public bool? ExternalPhases { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifierDate { get; set; }
        public int? IdMacroProcess { get; set; }
        public string ProcessCode { get; set; }
        public string ModUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public int? GenerateReport { get; set; }
    }
}
