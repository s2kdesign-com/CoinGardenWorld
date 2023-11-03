using Mapster;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class Garden : BaseEntity
    {
        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Name { get; set; }


        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }

        public Account Account { get; set; }

        public Visibility Visibility { get; set; } = Visibility.Public;

        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public ICollection<Flower> Flowers { get; set; }
    }
}
