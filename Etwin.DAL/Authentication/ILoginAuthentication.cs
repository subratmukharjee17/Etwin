using Etwin.DAL.Models;
using Etwin.Model;
using EtwLogin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.DAL.Authentication
{
    public interface ILoginAuthentication
    {
        Etwin.DAL.Models.Operator AuthenticateUser(string Username, string Passcode);
        Task<bool> VerifyUser(string Username);
       
    }
}
