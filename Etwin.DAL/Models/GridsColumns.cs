using System;
using System.Collections.Generic;
using System.Text;

namespace Etwin.DAL.Models
{
    public class GridsColumns
    {
        public int? ID { get; set; }
        public int? IDBand { get; set; }
        public string TestoColonna { get; set; }
        public string ToolTipColonna { get; set; }
        public string NomeColonna { get; set; }
        public string FontName { get; set; }
        public decimal FontSize { get; set; }
        public bool FontBold { get; set; }
        public int? IdTipoColonna { get; set; }
        //public string DataSource { get; set; }
        public int OrdineColonna { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }
        public bool Vertical { get; set; }
        public bool AllowGroup { get; set; }
        public bool Alert { get; set; }
        public bool Editabile { get; set; }
      //  public int? MinWidth { get; set; }
       // public bool MergeCell { get; set; }

        
    }
}
