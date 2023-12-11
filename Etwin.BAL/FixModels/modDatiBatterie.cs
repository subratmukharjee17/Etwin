using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ETwin.BAL.FixModels
{
    public class modDatiBatterie
    {
        public string Disegno   { get; set; }
        public string GeoT { get; set; }
        public string GeoR { get; set; }
        public string Volume { get; set; }
        public string Liquido1 { get; set; }
        public string Liquido2 { get; set; }
        public string Ped { get; set; }

        public string Famiglia { get; set; }

        public string TSint { get; set; }

        public string TSest { get; set; }

        public string PS { get; set; }

        public string PSest { get; set; }

        public string PT { get; set; }

        public string PTest { get; set; }

        public string Certificato { get; set; }

        public string Descrizione { get; set; }

        public string TipoTarga { get; set; }

        public string UserModifica { get; set; }

        public string DataModifica { get; set; }

        public string Code { get; set; }

        public int DN { get; set; }

    }
}
