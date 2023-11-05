using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record BadgeList
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string BadgeType { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}