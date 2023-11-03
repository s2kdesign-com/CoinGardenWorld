using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record GardenList
    {
        public string Name { get; set; }
        public Guid AccountId { get; set; }
        public AccountList Account { get; set; }
        public string Visibility { get; set; }
        public ICollection<FlowerList> Flowers { get; set; }
    }
}