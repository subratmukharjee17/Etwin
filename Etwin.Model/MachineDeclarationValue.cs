using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class MachineDeclarationValue
    {
        [Key]
        public int IdMachineDeclarationValue { get; set; }
        public int IdMachineDeclaration { get; set; }
        public int IdMachineDeclarationParameters { get; set; }
        [Required]
        [Column("MachineDeclarationValue")]
        [StringLength(50)]
        public string MachineDeclarationValue1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdMachineDeclaration))]
        [InverseProperty(nameof(MachineDeclaration.MachineDeclarationValues))]
        public virtual MachineDeclaration IdMachineDeclarationNavigation { get; set; }
    }
}
