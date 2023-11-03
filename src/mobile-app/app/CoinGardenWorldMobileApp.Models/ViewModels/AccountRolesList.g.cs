using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountRolesList
    {
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }
        public RoleList Role { get; set; }
    }
}