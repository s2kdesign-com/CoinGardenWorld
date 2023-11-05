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
        public Guid Id { get; set; }

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
