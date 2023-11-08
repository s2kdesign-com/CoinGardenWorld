using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountRoleAdd
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTimeOffset AssignedOn { get; set; }
    }
}