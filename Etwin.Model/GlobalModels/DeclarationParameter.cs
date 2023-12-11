using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class DeclarationParameter
    {
        [Key]
        public int IdDeclarationParameter { get; set; }
        [StringLength(50)]
        public string DeclarationParameters { get; set; }
        public int? IdValueType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdValueType))]
        [InverseProperty(nameof(ValueType.DeclarationParameters))]
        public virtual ValueType IdValueTypeNavigation { get; set; }
    }
}
