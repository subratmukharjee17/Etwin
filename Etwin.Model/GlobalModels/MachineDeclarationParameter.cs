using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class MachineDeclarationParameter
    {
        [Key]
        public int IdMachineDeclarationParameter { get; set; }
        [Required]
        [StringLength(50)]
        public string MachineParameter { get; set; }
        public int? IdValueType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdValueType))]
        [InverseProperty(nameof(ValueType.MachineDeclarationParameters))]
        public virtual ValueType IdValueTypeNavigation { get; set; }
    }
}
