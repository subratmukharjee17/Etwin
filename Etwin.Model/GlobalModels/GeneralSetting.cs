using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class GeneralSetting
    {
        [Key]
        public int Id { get; set; }
        public int IdDepartment { get; set; }
        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(IdDepartment))]
        [InverseProperty(nameof(Department.GeneralSettings))]
        public virtual Department IdDepartmentNavigation { get; set; }
    }
}
