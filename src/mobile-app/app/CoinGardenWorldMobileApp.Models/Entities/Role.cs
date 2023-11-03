using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class Role : BaseEntity
    {
        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? Description { get; set; }

        public Visibility Visibility { get; set; } = Visibility.Public;
    }
}
