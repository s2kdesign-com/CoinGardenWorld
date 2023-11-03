using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountRolesAdd
    {
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }
        public RoleAdd Role { get; set; }
    }
}