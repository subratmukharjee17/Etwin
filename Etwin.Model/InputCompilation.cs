using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("InputCompilation")]
    public partial class InputCompilation
    {
        [Key]
        public int Id { get; set; }
        public int IdInputControl { get; set; }
        public int IdInputControlToComplete { get; set; }
        [Required]
        public string Query { get; set; }

        [ForeignKey(nameof(IdInputControl))]
        [InverseProperty(nameof(InputControl.InputCompilationIdInputControlNavigations))]
        public virtual InputControl IdInputControlNavigation { get; set; }
        [ForeignKey(nameof(IdInputControlToComplete))]
        [InverseProperty(nameof(InputControl.InputCompilationIdInputControlToCompleteNavigations))]
        public virtual InputControl IdInputControlToCompleteNavigation { get; set; }
    }
}
