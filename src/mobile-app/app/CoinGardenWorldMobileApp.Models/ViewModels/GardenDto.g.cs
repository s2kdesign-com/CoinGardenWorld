using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record GardenDto
    {
        public string Name { get; set; }
        public Guid AccountId { get; set; }
        public AccountDto Account { get; set; }
        public string Visibility { get; set; }
        public ICollection<FlowerDto> Flowers { get; set; }
        public Guid Id { get; set; }
        public Guid CreatedFrom { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? UpdatedFrom { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public Guid? DeletedFrom { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}