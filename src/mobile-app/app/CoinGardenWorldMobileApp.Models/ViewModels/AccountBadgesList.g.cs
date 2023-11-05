using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record AccountBadgesList
    {
        public Guid AccountId { get; set; }
        public Guid BadgeId { get; set; }
        public BadgeList Badge { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}