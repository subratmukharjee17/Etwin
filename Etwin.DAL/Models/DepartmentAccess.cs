using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Etwin.DAL.Models
{
    public class DepartmentAccess
    {
        [Key]
        public int IdDepartmentAccess { get; set; }
        public string OperatorCode { get; set; }
        public int IdOperatorAccess { get; set; }
        public int IdDepartment { get; set; }
    }
}
