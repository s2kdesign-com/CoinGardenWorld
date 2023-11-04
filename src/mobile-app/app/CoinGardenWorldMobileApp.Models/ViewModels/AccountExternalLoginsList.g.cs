using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountExternalLoginsList
    {
        public Guid AccountId { get; set; }
        public string? DisplayName { get; set; }
        public string ObjectIdAzureAd { get; set; }
        public string? IdentityProvider { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}