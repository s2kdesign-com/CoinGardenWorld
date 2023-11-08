using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record BlobImageAdd
    {
        public Guid ImageId { get; set; }
        public string ImageUrl { get; set; }
    }
}