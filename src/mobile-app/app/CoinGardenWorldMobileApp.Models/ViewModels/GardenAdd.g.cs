using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record GardenAdd
    {
        public string Name { get; set; }
        public Guid AccountId { get; set; }
        public AccountAdd Account { get; set; }
        public Guid Id { get; set; }
        public Guid CreatedFrom { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? UpdatedFrom { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}