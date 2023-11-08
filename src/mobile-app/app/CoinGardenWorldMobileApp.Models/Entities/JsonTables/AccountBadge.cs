using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class AccountBadge
    {
        public Guid BadgeId { get; set; }
        public string BadgeName { get; set; }
        public string BadgeIcon { get; set; }
        public string BadgeColor { get; set; }

        public DateTimeOffset EarnedOn { get; set; } = DateTimeOffset.UtcNow;

    }
}
