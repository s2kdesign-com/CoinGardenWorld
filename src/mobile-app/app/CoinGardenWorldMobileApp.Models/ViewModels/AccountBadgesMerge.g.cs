using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountBadgesMerge
    {
        public Guid? AccountId { get; set; }
        public Guid? BadgeId { get; set; }
        public BadgeMerge Badge { get; set; }
    }
}