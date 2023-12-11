using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("DeclarationsFuture")]
    public partial class DeclarationsFuture
    {
        public DeclarationsFuture()
        {
            DeclarationsFutureValues = new HashSet<DeclarationsFutureValue>();
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
        [InverseProperty(nameof(PhasesCompany.DeclarationsFutures))]
        public virtual PhasesCompany IdPhaseCompanyNavigation { get; set; }
        [ForeignKey(nameof(IdProcessList))]
        [InverseProperty(nameof(ProcessesList.DeclarationsFutures))]
        public virtual ProcessesList IdProcessListNavigation { get; set; }
        [ForeignKey(nameof(OperatorCode))]
        [InverseProperty(nameof(Operator.DeclarationsFutures))]
        public virtual Operator OperatorCodeNavigation { get; set; }
        [InverseProperty(nameof(DeclarationsFutureValue.IdFutureDeclarationsNavigation))]
        public virtual ICollection<DeclarationsFutureValue> DeclarationsFutureValues { get; set; }
    }
}
