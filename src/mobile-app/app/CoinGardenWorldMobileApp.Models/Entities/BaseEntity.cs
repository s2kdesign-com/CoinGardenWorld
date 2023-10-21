using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public abstract class BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CreatedFrom { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public Guid? UpdatedFrom { get; set; } = null;

        public DateTime? UpdatedOn { get; set; } = null;



    }
}
