using System.Threading.Tasks;
using Etwin.DAL.Authentication;
using Etwin.DAL.Models;


namespace Etwin.BAL.Services
{
    public class AuthenticationService
    {
        private readonly ILoginAuthentication _loginAuthentication;
        public AuthenticationService(ILoginAuthentication loginAuthentication)
        { 
            _loginAuthentication= loginAuthentication;
        }

        /// <summary>
        /// AuthenticateUser
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Passcode"></param>
        /// <returns></returns>
        public Operator AuthenticateUser(string Username, string Passcode)
        {
            return _loginAuthentication.AuthenticateUser(Username, Passcode);
        }

        /// <summary>
        /// SendEmail
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public async Task<bool> SendEmail(string Username)
        {
            return await _loginAuthentication.VerifyUser(Username);
        }
    }
}
