namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountMerge
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? DisplayName { get; set; }
        public string? ProfileIntroduction { get; set; }
        public byte[]? ProfilePicure { get; set; }
    }
}