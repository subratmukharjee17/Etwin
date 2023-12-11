using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Assignment
    {
        [Key]
        public int Id { get; set; }
        public int IdProcessList { get; set; }
        public int IdPhaseCompany { get; set; }
        public int Priority { get; set; }
        [StringLength(30)]
        public string OperatorCodeAssignedBy { get; set; }
        [StringLength(30)]
        public string OperatorCodeAssignedTo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AssignedDate { get; set; }
        public bool ExternalAssignment { get; set; }

        [ForeignKey(nameof(IdPhaseCompany))]
        [InverseProperty(nameof(PhasesCompany.Assignments))]
        public virtual PhasesCompany IdPhaseCompanyNavigation { get; set; }
        [ForeignKey(nameof(IdProcessList))]
        [InverseProperty(nameof(ProcessesList.Assignments))]
        public virtual ProcessesList IdProcessListNavigation { get; set; }
        [ForeignKey(nameof(OperatorCodeAssignedBy))]
        [InverseProperty(nameof(Operator.AssignmentOperatorCodeAssignedByNavigations))]
        public virtual Operator OperatorCodeAssignedByNavigation { get; set; }
        [ForeignKey(nameof(OperatorCodeAssignedTo))]
        [InverseProperty(nameof(Operator.AssignmentOperatorCodeAssignedToNavigations))]
        public virtual Operator OperatorCodeAssignedToNavigation { get; set; }
    }
}
