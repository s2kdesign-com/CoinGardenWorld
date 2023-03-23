

using CoinGardenWorld.MailKit.Models.Mail;

namespace CoinGardenWorld.MailKit.Interfaces {
    public interface IMailService {
        Task SendAsync(MailRequest request);
    }
}
