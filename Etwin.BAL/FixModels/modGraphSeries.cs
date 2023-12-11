using System;

namespace ETwin.BAL.FixModels
{
    public class modGraphSeries
    {
        public string SeriesName { get; set; }
        //DA CONVERTIRE IN BASE ALLO SCALETYPE
        public string ArgumentDataMember { get; set; }
        public float ValueDataMember { get; set; }
        public string? ColorDataMember { get; set; }
        public string? Point { get; set; }

    }

    public class modGraphSeriesDate
    {
        public string SeriesName { get; set; }
        //DA CONVERTIRE IN BASE ALLO SCALETYPE
        public DateTime ArgumentDataMember { get; set; }
        public float ValueDataMember { get; set; }
        public string? ColorDataMember { get; set; }
        public string? Point { get; set; }

    }

}
