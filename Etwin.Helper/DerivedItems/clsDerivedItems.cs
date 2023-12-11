using LogDll;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.Helper.DerivedItems
{
    public partial class clsDerivedItems
    {
        public int idBom;

        public int IdBom
        {
            get { return this.idBom; }
            set { this.idBom = value; }
        }

        public void CreateItemChild(int idBom)
        {
            try
            {
                this.IdBom = idBom;
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

    }
}
