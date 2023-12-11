using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("TraceabilityParameter")]
    public partial class TraceabilityParameter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ParameterName { get; set; }
        public string Query { get; set; }
        public int IdValueType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdValueType))]
        [InverseProperty(nameof(ValueType.TraceabilityParameters))]
        public virtual ValueType IdValueTypeNavigation { get; set; }
    }
}
