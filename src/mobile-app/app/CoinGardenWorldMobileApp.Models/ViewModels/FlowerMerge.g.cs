using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record FlowerMerge
    {
        public string Name { get; set; }
        public string Visibility { get; set; }
        public Guid? AccountId { get; set; }
    }
}