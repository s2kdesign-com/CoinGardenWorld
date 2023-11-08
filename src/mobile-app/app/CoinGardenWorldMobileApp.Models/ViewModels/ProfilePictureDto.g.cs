using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record ProfilePictureDto
    {
        public string Description { get; set; }
        public BlobImageDto Image { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}