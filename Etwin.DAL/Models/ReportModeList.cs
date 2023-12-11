using System;
using System.Collections.Generic;
using System.Text;

namespace Etwin.DAL.Models
{
   public class ReportModeList
    {
        public string SqlQuery { get; set; }
        public string ControlName { get; set; }
        public int? IdControl { get; set; }
        public int? IdControlType { get; set; }
        public string AllowDragDrop { get;set; }
        public bool? TreeList { get; set; }
    }
}
