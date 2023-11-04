using CoinGardenWorldMobileApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorldMobileApp.Models.Entities;

namespace CoinGardenWorldMobileApp.Models.DerivedModels
{
    public class ProfileOnLoginRequest 
    {
        public AccountAdd Account { get; set; }
        public AccountExternalLoginsMerge ExternalLogins { get; set; }


    }
}
