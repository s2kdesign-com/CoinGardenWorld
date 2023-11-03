using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record RoleDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid Id { get; set; }
        public Guid CreatedFrom { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? UpdatedFrom { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public Guid? DeletedFrom { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}