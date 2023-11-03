using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountRolesDto
    {
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }
        public RoleDto Role { get; set; }
        public Guid Id { get; set; }
        public Guid CreatedFrom { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? UpdatedFrom { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public Guid? DeletedFrom { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}