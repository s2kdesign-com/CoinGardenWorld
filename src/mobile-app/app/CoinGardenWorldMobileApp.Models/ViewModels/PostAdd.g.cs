using System;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record PostAdd
    {
        public Guid AccountId { get; set; }
        public AccountAdd Account { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LinkOrImageUrl { get; set; }
        public string PostType { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}