using Etwin.DAL.DataRepository;
using Etwin.Helper.MailHelper;
using Etwin.DAL.Models;
using EtwLogin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.DAL.Authentication
{
    public class LoginAuthentication : ILoginAuthentication
    {
        private readonly IGenericRepository<Operator> _genericRepository;
        private readonly IEmailService _emailService;
        public LoginAuthentication(IGenericRepository<Operator> genericRepository, IEmailService emailService)
        {
            _genericRepository = genericRepository;
            _emailService = emailService;
        }

        /// <summary>
        /// AuthenticateUser
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Passcode"></param>
        /// <returns></returns>
        public Operator AuthenticateUser(string Username, string Passcode)
        {

            return _genericRepository
                .GetWithFilters(x => x.Username == Username && x.Password == Passcode,
                    x => new Operator { IdOperator = x.IdOperator, NameSurname = x.NameSurname })
                .FirstOrDefault();
        }
        public async Task<bool> VerifyUser(string Username)
        {
            var modelData = _genericRepository.GetWithFilters(x => x.Username == Username,
                                    x => new { x.IdOperator });
            if (modelData.Count != 0)
            {
                var OpCode = modelData.FirstOrDefault().IdOperator;
                return await _emailService.SendEmailAsync(Username);
            }
            else
            {
                return false;
            }

        }
    }
}

