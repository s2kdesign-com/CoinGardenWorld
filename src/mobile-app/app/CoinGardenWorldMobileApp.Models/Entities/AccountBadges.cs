using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class AccountBadges : BaseEntity
    {
        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }

        public Account Account { get; set; }



        [ForeignKey(nameof(Badge))]
        public Guid BadgeId { get; set; }

        public Badge Badge { get; set; }
    }
}
