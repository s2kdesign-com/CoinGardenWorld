using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountRolesMerge
    {
        public Guid? RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTimeOffset? AssignedOn { get; set; }
    }
}