﻿//using EtwLogin.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;


namespace Etwin.Helper.MailHelper
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _configuration;

        private string DisplayName { get { return _configuration.GetSection("MailSettings")["DisplayName"]; } }
        private string FromMail { get { return _configuration.GetSection("MailSettings")["FromMail"]; } }
        private string Subject { get { return _configuration.GetSection("MailSettings")["Subject"]; } }
        private string Body { get { return _configuration.GetSection("MailSettings")["Body"]; } }
        private string Host { get { return _configuration.GetSection("MailSettings")["Host"]; } }
        private string Port { get { return _configuration.GetSection("MailSettings")["Port"]; } }
        private string Password { get { return _configuration.GetSection("MailSettings")["Password"]; } }

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
            



        public async Task<bool> SendEmailAsync(string toUserName)
        {
            try
            {
                var mail = new MimeMessage();

                mail.From.Add(new MailboxAddress(DisplayName, FromMail));
                mail.Sender = new MailboxAddress(DisplayName, FromMail);
                mail.To.Add(MailboxAddress.Parse(_configuration.GetSection("MailSettings")["ToMail"]));
                var body = new BodyBuilder();
                mail.Subject = _configuration.GetSection("MailSettings")["Subject"];


                string htmlString = @"<html>
                      <body>
                      <p>Dear Admin Team,</p>
                      <p> User :<span color:green;font-weight:bold;>" + toUserName + @" <span></p>
                      <p> Above user forgot the password. Please provide assistance.</p>
                      <p>Thank you ,<br>Etwin Team</br></p>
                      </body>
                      </html>
                     ";

                string emailbodydata = htmlString;// toUserName + _configuration.GetSection("MailSettings")["Body"];
                body.HtmlBody = emailbodydata;
                mail.Body = body.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(Host, int.Parse(Port), SecureSocketOptions.StartTls);

                await smtp.AuthenticateAsync(FromMail, Password);
                await smtp.SendAsync(mail);
                await smtp.DisconnectAsync(true);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
