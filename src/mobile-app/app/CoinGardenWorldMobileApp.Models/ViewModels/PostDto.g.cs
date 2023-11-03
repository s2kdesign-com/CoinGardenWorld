using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record PostDto
    {
        public Guid AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? LinkOrImageUrl { get; set; }
        public Guid? GardenId { get; set; }
        public GardenDto? Garden { get; set; }
        public Guid? FlowerId { get; set; }
        public FlowerDto? Flower { get; set; }
        public string PostType { get; set; }
        public string Visibility { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}