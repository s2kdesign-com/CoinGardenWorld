using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record FlowerAdd
    {
        public string Name { get; set; }
        public List<BlobImageAdd> Images { get; set; }
        public string Visibility { get; set; }
        public Guid AccountId { get; set; }
    }
}