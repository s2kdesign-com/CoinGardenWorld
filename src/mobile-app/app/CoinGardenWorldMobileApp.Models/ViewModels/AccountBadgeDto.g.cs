using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountBadgeDto
    {
        public Guid BadgeId { get; set; }
        public string BadgeName { get; set; }
        public string BadgeIcon { get; set; }
        public string BadgeColor { get; set; }
        public DateTimeOffset EarnedOn { get; set; }
    }
}