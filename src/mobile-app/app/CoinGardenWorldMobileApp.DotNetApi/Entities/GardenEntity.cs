using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinGardenWorldMobileApp.DotNetApi.Entities
{
    public class GardenEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Name { get; set; }


        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }

        public AccountEntity Account { get; init; }


        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public List<FlowerEntity> Flowers { get; } = new();
    }
}
