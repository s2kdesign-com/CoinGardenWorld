using CoinGardenWorldMobileApp.Models.Attributes;
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

        [IgnoreOnInsert]
        public Guid CreatedFrom { get; set; }

        [IgnoreOnUpdate]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [IgnoreOnInsert]
        public Guid? UpdatedFrom { get; set; } = null;
        [IgnoreOnUpdate]
        public DateTime? UpdatedOn { get; set; } = null;



    }
}
