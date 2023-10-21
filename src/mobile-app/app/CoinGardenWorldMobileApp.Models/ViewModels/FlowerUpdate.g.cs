using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record FlowerUpdate
    {
        public string Name { get; set; }
        public Guid GardenId { get; set; }
        public Guid CreatedFrom { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? UpdatedFrom { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}