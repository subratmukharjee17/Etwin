using System;
using System.Collections.Generic;
using System.Text;

namespace Etwin.DAL.Models
{
    public class Operator
    {
        public int IdOperator { get; set; }   
        
        public string NameSurname { get; set; } 

        public  int IdCompany { get; set; }

        public  string Username { get; set; }

        public string Password { get; set; }

        public char RememberPassword { get; set; }

        public char Active { get; set; }


    }
}
