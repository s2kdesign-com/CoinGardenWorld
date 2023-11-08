using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountList
    {
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? DisplayName { get; set; }
        public string? ProfileIntroduction { get; set; }
        public BlobImageList? ProfilePicture { get; set; }
        public List<AccountBadgeList?>? Badges { get; set; }
        public List<AccountRoleList?>? Roles { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}