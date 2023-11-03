
//using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mapster;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class Flower : BaseEntity
    {
        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Name { get; set; }


        public Visibility Visibility { get; set; } = Visibility.Public;

        [ForeignKey(nameof(Garden))]
        public Guid GardenId { get; set; }
        public Garden Garden { get; set; }
    }
}
