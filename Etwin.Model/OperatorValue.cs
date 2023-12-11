using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class OperatorValue
    {
        [Key]
        public int IdOperatorValue { get; set; }
        public int IdOperatorParameter { get; set; }
        [Required]
        [StringLength(30)]
        public string OperatorCode { get; set; }
        [Required]
        [StringLength(100)]
        public string Value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(OperatorCode))]
        [InverseProperty(nameof(Operator.OperatorValues))]
        public virtual Operator OperatorCodeNavigation { get; set; }
    }
}
