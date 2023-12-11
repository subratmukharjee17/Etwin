using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public int? IdDepartment { get; set; }
        [StringLength(256)]
        public string WareHouseName { get; set; }
        public int? IdWareHouseType { get; set; }

        [ForeignKey(nameof(IdDepartment))]
        [InverseProperty(nameof(Department.Warehouses))]
        public virtual Department IdDepartmentNavigation { get; set; }
        [ForeignKey(nameof(IdWareHouseType))]
        [InverseProperty(nameof(WarehouseType.Warehouses))]
        public virtual WarehouseType IdWareHouseTypeNavigation { get; set; }
    }
}
