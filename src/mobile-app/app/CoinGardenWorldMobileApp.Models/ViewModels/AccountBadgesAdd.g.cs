using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountBadgesAdd
    {
        public Guid AccountId { get; set; }
        public Guid BadgeId { get; set; }
        public BadgeAdd Badge { get; set; }
    }
}