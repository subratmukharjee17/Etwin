using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Etwin.DAL.Model
{
    public class RibbonsPages
    {
        [Key]
        public int Id { get; set; }
        public int IdRibbon { get; set; }
        public string RibbonPageName { get; set; }
        public string RibbonPageTitle { get; set; }
        public string RibbonPageImage { get; set; }
        public int Ordine { get; set; }
        public int IdDepartment { get; set; }
    }
}
