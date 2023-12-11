using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class ClsTimbratore
    {
        public string? OperatorCode { get; set; }
        public string TitoloTimbratore { get; set; }
        public string DescrizioneTimbratore{ get; set; }
        public string ControlState { get; set; }
        public string TestoScorrevole { get; set; }
        public string Immagine { get; set; }
        public string? IdProcessList {  get; set; }

    }
}
