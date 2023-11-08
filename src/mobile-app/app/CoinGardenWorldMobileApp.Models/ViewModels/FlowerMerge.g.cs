using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record FlowerMerge
    {
        public string Name { get; set; }
        public List<BlobImageMerge> Images { get; set; }
        public string Visibility { get; set; }
        public Guid? AccountId { get; set; }
    }
}