using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenBotCore_Api.Models.DTO {
    public class RecognizedFlowerModel {
        public string Name { get; set; }

        public string Region { get; set; }

        public decimal Probability { get; set; }
    }
}
