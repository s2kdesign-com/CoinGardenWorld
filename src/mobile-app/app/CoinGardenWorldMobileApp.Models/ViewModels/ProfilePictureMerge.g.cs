using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record ProfilePictureMerge
    {
        public string Description { get; set; }
        public BlobImageMerge Image { get; set; }
    }
}