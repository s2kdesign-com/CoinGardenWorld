using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.DerivedModels
{
    public class ProfileOnLogin
    {
        public Guid AccountId { get; set; }

        public bool IsFirstRegistration { get; set; }
    }
}
