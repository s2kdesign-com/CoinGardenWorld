using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record PostMerge
    {
        public Guid? AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? LinkOrImageUrl { get; set; }
        public Guid? GardenId { get; set; }
        public GardenMerge? Garden { get; set; }
        public Guid? FlowerId { get; set; }
        public FlowerMerge? Flower { get; set; }
        public string PostType { get; set; }
        public string Visibility { get; set; }
    }
}