﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.Helper.MailHelper
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string emailId);
    }
}
