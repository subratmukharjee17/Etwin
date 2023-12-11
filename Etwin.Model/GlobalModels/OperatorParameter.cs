using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class OperatorParameter
    {
        [Key]
        public int IdOperatorParameter { get; set; }
        [Required]
        [Column("OperatorParameter")]
        [StringLength(50)]
        public string OperatorParameter1 { get; set; }
        public bool IsSensitiveData { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public int? IdValueType { get; set; }

        [ForeignKey(nameof(IdValueType))]
        [InverseProperty(nameof(ValueType.OperatorParameters))]
        public virtual ValueType IdValueTypeNavigation { get; set; }
    }
}
