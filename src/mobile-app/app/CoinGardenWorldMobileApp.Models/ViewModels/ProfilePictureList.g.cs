using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record ProfilePictureList
    {
        public string Description { get; set; }
        public BlobImageList Image { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}