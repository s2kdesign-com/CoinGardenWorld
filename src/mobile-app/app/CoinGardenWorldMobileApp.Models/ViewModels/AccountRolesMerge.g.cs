using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountRolesMerge
    {
        public Guid? AccountId { get; set; }
        public Guid? RoleId { get; set; }
        public RoleMerge Role { get; set; }
    }
}