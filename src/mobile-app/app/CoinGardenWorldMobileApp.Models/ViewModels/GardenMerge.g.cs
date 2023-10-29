using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record GardenMerge
    {
        public string Name { get; set; }
        public Guid? AccountId { get; set; }
        public AccountMerge Account { get; set; }
    }
}