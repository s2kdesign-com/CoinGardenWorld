using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountAdd
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? DisplayName { get; set; }
        public string? ProfileIntroduction { get; set; }
        public byte[]? ProfilePicure { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}