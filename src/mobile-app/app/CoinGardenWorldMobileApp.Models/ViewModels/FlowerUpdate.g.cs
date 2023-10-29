using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record FlowerUpdate
    {
        public string Name { get; set; }
        public Guid GardenId { get; set; }
    }
}