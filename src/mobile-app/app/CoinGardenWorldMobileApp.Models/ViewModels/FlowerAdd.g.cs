using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record FlowerAdd
    {
        public string Name { get; set; }
        public Guid GardenId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}