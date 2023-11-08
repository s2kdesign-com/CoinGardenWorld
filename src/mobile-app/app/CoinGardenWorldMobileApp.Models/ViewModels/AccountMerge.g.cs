using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountMerge
    {
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? DisplayName { get; set; }
        public string? ProfileIntroduction { get; set; }
        public BlobImageMerge? ProfilePicture { get; set; }
        public List<AccountBadgeMerge?>? Badges { get; set; }
        public List<AccountRoleMerge?>? Roles { get; set; }
    }
}