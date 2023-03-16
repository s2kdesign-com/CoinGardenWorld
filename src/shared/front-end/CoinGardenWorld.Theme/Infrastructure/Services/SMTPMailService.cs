using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorld.Theme.Configurations;
using CoinGardenWorld.Theme.Infrastructure.Services.Interfaces;
using CoinGardenWorld.Theme.Models.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CoinGardenWorld.Theme.Infrastructure.Services {
    public class SMTPMailService : IMailService {
        private readonly MailConfiguration _config;
        private readonly ILogger<SMTPMailService> _logger;

        public SMTPMailService(IOptions<MailConfiguration> config, ILogger<SMTPMailService> logger) {
            _config = config.Value;
            _logger = logger;
        }

        public async Task SendAsync(MailRequest request) {
            try {
                var email = new MimeMessage {
                    Sender = new MailboxAddress(_config.DisplayName, request.From ?? _config.From),
                    Subject = request.Subject,
                    Body = new BodyBuilder {
                        HtmlBody = request.Body
                    }.ToMessageBody()
                };
                email.To.Add(MailboxAddress.Parse(request.To));
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_config.Host, _config.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_config.UserName, _config.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (System.Exception ex) {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
