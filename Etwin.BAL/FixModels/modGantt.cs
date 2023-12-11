using System;

namespace ETwin.BAL.FixModels
{
    public class modGantt
    {
        public string KeyFieldName { get; set; }
        public string ParentFieldName { get; set; }
        public string TextFieldName { get; set; }
        public DateTime StartDateFieldName { get; set; }
        public DateTime FinishDateFieldName { get; set; }
        public string ProgressFieldName { get; set; }
        public string PredecessorsFieldName { get; set; }

    }

}
