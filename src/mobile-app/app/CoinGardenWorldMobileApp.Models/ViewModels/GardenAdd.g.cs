using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record GardenAdd
    {
        public string Name { get; set; }
        public Guid AccountId { get; set; }
        public AccountAdd Account { get; set; }
        public string Visibility { get; set; }
        public ICollection<FlowerAdd> Flowers { get; set; }
    }
}