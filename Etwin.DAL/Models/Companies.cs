using System;
using System.Collections.Generic;
using System.Text;

namespace Etwin.DAL.Models
{
    public class Companies
    {

        public int IdCompany { get; set; } 
        public string CompanyName { get; set; }
        public string ConnectionString { get; set; }
        public string? CompanyLogo { get; set; } 
        public string WebSite { get; set; }

    }
}
