using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record ProfilePictureAdd
    {
        public string Description { get; set; }
        public BlobImageAdd Image { get; set; }
    }
}