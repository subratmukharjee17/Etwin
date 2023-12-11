using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class Department
    {
        public Department()
        {
            GeneralSettings = new HashSet<GeneralSetting>();
            Phases = new HashSet<Phase>();
            Warehouses = new HashSet<Warehouse>();
        }

        [Key]
        public int IdDepartment { get; set; }
        [StringLength(2)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public string IconName { get; set; }

        [InverseProperty(nameof(GeneralSetting.IdDepartmentNavigation))]
        public virtual ICollection<GeneralSetting> GeneralSettings { get; set; }
        [InverseProperty(nameof(Phase.IdDepartmentNavigation))]
        public virtual ICollection<Phase> Phases { get; set; }
        [InverseProperty(nameof(Warehouse.IdDepartmentNavigation))]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
