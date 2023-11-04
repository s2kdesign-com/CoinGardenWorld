using CoinGardenWorldMobileApp.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class AccountExternalLogins : BaseEntity
    {


        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }

        [IgnoreOnModify]
        public Account Account { get; set; }


        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? DisplayName { get; set; }

        [StringLength(70, ErrorMessage = "{0} can have a max of {1} characters")]
        public string ObjectIdAzureAd { get; set; } 

        [StringLength(70, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? IdentityProvider { get; set; }

        [StringLength(8000, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? ProfilePictureUrl { get; set; }
    }
}
