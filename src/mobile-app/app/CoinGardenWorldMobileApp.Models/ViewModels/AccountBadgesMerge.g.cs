using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountBadgesMerge
    {
        public Guid? BadgeId { get; set; }
        public string BadgeName { get; set; }
        public DateTimeOffset? EarnedOn { get; set; }
    }
}