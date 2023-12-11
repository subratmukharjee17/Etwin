using System;
using System.Collections.Generic;
using System.Text;

namespace Etwin.DAL.Models
{
    public class Bands
    {
        public int? ID { get; set; }
        public int? IdGrid { get; set; }
        public string BandName { get; set; }
        public string Caption { get; set; }
        public string ToolTip { get; set; }
        public string FontName { get; set; }
        public decimal FontSize { get; set; }
        public bool FontBold { get; set; }
        public int? Ordine { get; set; }
        public int? BandFixed { get; set; }
    }
}
