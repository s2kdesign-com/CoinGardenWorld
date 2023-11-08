using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record BlobImageDto
    {
        public Guid ImageId { get; set; }
        public string ImageUrl { get; set; }
    }
}