using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class ProfilePicture : BaseEntity
    {
        public string Description { get; set; }

        public BlobImage Image { get; set; }
    }
}
