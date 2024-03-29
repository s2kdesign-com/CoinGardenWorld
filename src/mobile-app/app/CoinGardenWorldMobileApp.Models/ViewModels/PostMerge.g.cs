using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record PostMerge
    {
        public Guid? AccountId { get; set; }
        public AccountMerge Account { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ExternalUrl { get; set; }
        public List<BlobImageMerge?>? Images { get; set; }
        public string? PostType { get; set; }
        public string? Visibility { get; set; }
    }
}