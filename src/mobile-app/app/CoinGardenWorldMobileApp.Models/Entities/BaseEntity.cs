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

        [IgnoreOnInsert]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [IgnoreOnUpdate]
        [IgnoreOnInsert]
        public Guid? UpdatedFrom { get; set; } = null;

        [IgnoreOnUpdate]
        [IgnoreOnInsert]
        public DateTime? UpdatedOn { get; set; } = null;

        
        //public Guid? DeletedFrom { get; set; } = null;

        //public DateTime? WhenDeleted { get; set; } = null;
    }
}
