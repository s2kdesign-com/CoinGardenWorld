
//using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoinGardenWorldMobileApp.DotNetApi.Entities
{
    public class FlowerDTO : BaseDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Name { get; set; }



        [ForeignKey(nameof(Garden))]
        public Guid GardenId { get; set; }
        public GardenDTO Garden { get; init; }
    }
}
