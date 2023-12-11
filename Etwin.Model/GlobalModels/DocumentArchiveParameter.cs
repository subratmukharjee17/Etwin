using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class DocumentArchiveParameter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DocumentParameter { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public int? IdValueType { get; set; }

        [ForeignKey(nameof(IdValueType))]
        [InverseProperty(nameof(ValueType.DocumentArchiveParameters))]
        public virtual ValueType IdValueTypeNavigation { get; set; }
    }
}
