using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorldMobileApp.Models.Attributes;
using CoinGardenWorldMobileApp.Models.Entities.Enums;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class Post : BaseEntity
    {
        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = new Account();

        [StringLength(300, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? Title { get; set; }

        [StringLength(1500, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? Content { get; set; }

        public string? ExternalUrl { get; set; }

        public List<BlobImage>? Images { get; set; }

        public PostType PostType { get; set; }

        public Visibility Visibility { get; set; } = Visibility.Public;


    }
    
}
