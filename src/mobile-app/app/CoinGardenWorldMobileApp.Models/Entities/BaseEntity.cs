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

        [IgnoreOnInsert]
        public Guid CreatedFrom { get; set; }

        [IgnoreOnInsert]
        public DateTimeOffset CreatedOn { get; set; } = DateTime.UtcNow;

        [IgnoreOnUpdate]
        [IgnoreOnInsert]
        public Guid? UpdatedFrom { get; set; } = null;

        [IgnoreOnUpdate]
        [IgnoreOnInsert]
        public DateTimeOffset? UpdatedOn { get; set; } = null;

        [IgnoreOnUpdate]
        [IgnoreOnInsert]
        public Guid? DeletedFrom { get; set; } = null;

        [IgnoreOnUpdate]
        [IgnoreOnInsert]
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
