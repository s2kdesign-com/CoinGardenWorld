using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record GardenUpdate
    {
        public string Name { get; set; }
        public Guid AccountId { get; set; }
        public AccountUpdate Account { get; set; }
        public Guid CreatedFrom { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? UpdatedFrom { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}