using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record GardenMerge
    {
        public string Name { get; set; }
        public Guid? AccountId { get; set; }
        public string Visibility { get; set; }
    }
}