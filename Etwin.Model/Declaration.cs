using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Declaration
    {
        public Declaration()
        {
            DeclarationValues = new HashSet<DeclarationValue>();
        }

        [Key]
        public int IdDeclaration { get; set; }
        [Required]
        [StringLength(30)]
        public string OperatorCode { get; set; }
        public int? IdProcessList { get; set; }
        public int IdPhaseCompany { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeclarationDate { get; set; }
        public int? IdTimestep { get; set; }
        public int? IdPhaseState { get; set; }
        public int? IdPhaseActivity { get; set; }

        [ForeignKey(nameof(IdPhaseCompany))]
        [InverseProperty(nameof(PhasesCompany.Declarations))]
        public virtual PhasesCompany IdPhaseCompanyNavigation { get; set; }
        [ForeignKey(nameof(IdProcessList))]
        [InverseProperty(nameof(ProcessesList.Declarations))]
        public virtual ProcessesList IdProcessListNavigation { get; set; }
        [ForeignKey(nameof(OperatorCode))]
        [InverseProperty(nameof(Operator.Declarations))]
        public virtual Operator OperatorCodeNavigation { get; set; }
        [InverseProperty(nameof(DeclarationValue.IdDeclarationsNavigation))]
        public virtual ICollection<DeclarationValue> DeclarationValues { get; set; }
    }
}
