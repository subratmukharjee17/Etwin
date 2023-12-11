using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("DeclarationsFutureValue")]
    public partial class DeclarationsFutureValue
    {
        [Key]
        public int IdDeclarationValues { get; set; }
        public int? IdFutureDeclarations { get; set; }
        public int? IdDeclarationParameters { get; set; }
        [StringLength(100)]
        public string DeclarationValue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdFutureDeclarations))]
        [InverseProperty(nameof(DeclarationsFuture.DeclarationsFutureValues))]
        public virtual DeclarationsFuture IdFutureDeclarationsNavigation { get; set; }
    }
}
