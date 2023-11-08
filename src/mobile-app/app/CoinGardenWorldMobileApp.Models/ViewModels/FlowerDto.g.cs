using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record FlowerDto
    {
        public string Name { get; set; }
        public List<BlobImageDto> Images { get; set; }
        public string Visibility { get; set; }
        public Guid AccountId { get; set; }
        public AccountDto Account { get; set; }
        public Guid? GardenId { get; set; }
        public GardenDto? Garden { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}