using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class PresenceDeclaration
    {
        [Key]
        public int IdPresenceDeclaration { get; set; }
        [Required]
        [StringLength(30)]
        public string OperatorCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DeclarationDate { get; set; }
        public int IdPresenceState { get; set; }

        [ForeignKey(nameof(OperatorCode))]
        [InverseProperty(nameof(Operator.PresenceDeclarations))]
        public virtual Operator OperatorCodeNavigation { get; set; }
    }
}
