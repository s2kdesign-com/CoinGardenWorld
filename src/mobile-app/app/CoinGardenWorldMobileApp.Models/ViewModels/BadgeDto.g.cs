using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record BadgeDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public string? Description { get; set; }
        public string BadgeType { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}