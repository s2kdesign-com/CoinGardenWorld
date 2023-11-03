namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountList
    {
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? DisplayName { get; set; }
        public string? ProfileIntroduction { get; set; }
        public byte[]? ProfilePicure { get; set; }
        public string? UserObjectIdAzureAd { get; set; }
        public string? UserIdentityProvider { get; set; }
    }
}