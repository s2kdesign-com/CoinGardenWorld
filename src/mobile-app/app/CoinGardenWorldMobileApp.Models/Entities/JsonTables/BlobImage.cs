using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class BlobImage
    {
        public Guid ImageId { get; set; }

        public string ImageUrl { get; set; } = "";
    }
}
