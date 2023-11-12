using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mapster;
using CoinGardenWorldMobileApp.Models.Attributes;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class Account : BaseEntity
    {
        //The placeholders I am aware of are:
        // 
        // {0} = Property Name
        // {1} = Max Length
        // {2} = Min Length
        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Email { get; set; }

        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? Username { get; set; }

        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? DisplayName { get; set; }

        [StringLength(500, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? ProfileIntroduction { get; set; }

        public BlobImage? ProfilePicture { get; set; } = new ();

        public List<AccountBadge>? Badges { get; set; } = new();

        public List<AccountRole>? Roles { get; set; } = new();

        [IgnoreOnList]
        public List<AccountExternalLogins>? ExternalLogins { get; set; } = new();

    }
}
