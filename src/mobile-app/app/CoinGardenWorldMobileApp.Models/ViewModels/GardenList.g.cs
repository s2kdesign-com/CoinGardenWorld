using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record GardenList
    {
        public string Name { get; set; }
        public Guid AccountId { get; set; }
        public AccountList Account { get; set; }
        public string Visibility { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}