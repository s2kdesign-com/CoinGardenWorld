
using CoinGardenWorld.Theme.Models.Mail;

namespace CoinGardenWorld.Theme.Infrastructure.Services.Interfaces {
    public interface IMailService {
        Task SendAsync(MailRequest request);
    }
}
