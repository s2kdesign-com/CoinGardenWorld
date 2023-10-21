using System.ComponentModel.DataAnnotations;
using CoinGardenWorldMobileApp.Models.ViewModels.Interfaces;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public class AccountDTO : IBaseDTO
    {
        public Guid Id { get; set; } 

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string? Username { get; set; }

        public string? DisplayName { get; set; }

        public string? ProfileIntroduction { get; set; }

        public byte[]? ProfilePicure { get; set; }

    }
}
