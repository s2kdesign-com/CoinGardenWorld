using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record FlowerList
    {
        public string Name { get; set; }
        public string Visibility { get; set; }
        public Guid GardenId { get; set; }
    }
}