using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record BlobImageList
    {
        public Guid ImageId { get; set; }
        public string ImageUrl { get; set; }
    }
}