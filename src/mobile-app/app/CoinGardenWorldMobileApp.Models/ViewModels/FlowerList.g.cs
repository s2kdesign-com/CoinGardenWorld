using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record FlowerList
    {
        public string Name { get; set; }
        public string Visibility { get; set; }
        public Guid? GardenId { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}