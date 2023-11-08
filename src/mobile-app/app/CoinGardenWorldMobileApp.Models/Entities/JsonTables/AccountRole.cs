using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class AccountRole
    {
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public DateTimeOffset AssignedOn { get; set; } = DateTimeOffset.UtcNow;

    }
}
