using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class DeclarationValue
    {
        [Key]
        public int IdDeclarationValues { get; set; }
        public int IdDeclarations { get; set; }
        public int IdDeclarationParameters { get; set; }
        [Required]
        [Column("DeclarationValue")]
        [StringLength(100)]
        public string DeclarationValue1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdDeclarations))]
        [InverseProperty(nameof(Declaration.DeclarationValues))]
        public virtual Declaration IdDeclarationsNavigation { get; set; }
    }
}
