using CoinGardenWorldMobileApp.Models.Attributes;
using CoinGardenWorldMobileApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public abstract class BaseEntity : ISoftDelete
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [IgnoreOnModify]
        public DateTimeOffset CreatedOn { get; set; } = DateTime.UtcNow;

        [IgnoreOnList]
        [IgnoreOnModify]
        public DateTimeOffset? UpdatedOn { get; set; } = null;

        [IgnoreOnList]
        [IgnoreOnModify]
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
