using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("DepartmentAccess")]
    public partial class DepartmentAccess
    {
        [Key]
        public int IdDepartmentAccess { get; set; }
        [Required]
        [StringLength(30)]
        public string OperatorCode { get; set; }
        public int IdOperatorAccess { get; set; }
        public int IdDepartment { get; set; }

        [ForeignKey(nameof(OperatorCode))]
        [InverseProperty(nameof(Operator.DepartmentAccesses))]
        public virtual Operator OperatorCodeNavigation { get; set; }
    }
}
