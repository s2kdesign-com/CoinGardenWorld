using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountAdd
    {
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? DisplayName { get; set; }
        public string? ProfileIntroduction { get; set; }
        public BlobImageAdd? ProfilePicture { get; set; }
        public List<AccountBadgeAdd?>? Badges { get; set; }
        public List<AccountRoleAdd?>? Roles { get; set; }
    }
}