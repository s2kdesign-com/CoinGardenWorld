using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record PostAdd
    {
        public Guid AccountId { get; set; }
        public AccountAdd Account { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ExternalUrl { get; set; }
        public List<BlobImageAdd?>? Images { get; set; }
        public string? PostType { get; set; }
        public string? Visibility { get; set; }
    }
}