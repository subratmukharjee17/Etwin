using System;
using System.Collections.Generic;
using System.Text;

namespace Etwin.DAL.Models
{
  public  class ReportChartModeList
    {
        public double ValueDataMember { get; set; }
        public string SeriesName { get; set; }
        public DateTime ArgumentDataMember { get; set; }

        public List<ReportOrderWithPhaseList> reportOrderWithPhaseList { get; set; }
    }
   
}
