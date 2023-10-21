using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class BaseEntity
    {
        public Guid CreatedFrom { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public Guid? UpdatedFrom { get; set; } 

        public DateTime? UpdatedOn { get; set; }


        [ForeignKey(nameof(CreatedFrom))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public AccountEntity CreatedFromAccount { get; init; }


        [ForeignKey(nameof(UpdatedFrom))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public AccountEntity UpdatedFromAccount { get; init; }

    }
}
