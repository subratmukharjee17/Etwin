using System;
using System.Collections.Generic;
using System.Text;

namespace ETwin.DAL.Models
{

    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public ConnectionStringCustomer CsCust {  get; set; }   
    }

    public class ConnectionStrings
    {
        public string MbkDbConstr { get; set; }
    }

    public class ConnectionStringCustomer
    {
        public string CsCust { get; set;}
    }

}
