using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record GardenMerge
    {
        public string Name { get; set; }
        public Guid? AccountId { get; set; }
        public AccountMerge Account { get; set; }
        public ICollection<FlowerMerge> Flowers { get; set; }
    }
}