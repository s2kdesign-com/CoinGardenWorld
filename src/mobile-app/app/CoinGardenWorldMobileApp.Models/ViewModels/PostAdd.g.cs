using System;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record PostAdd
    {
        public Guid AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LinkOrImageUrl { get; set; }
        public string PostType { get; set; }
    }
}