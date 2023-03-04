using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenBotCore_Api.Models.Requests {
    public class RecognizeFlowerByNameRequest {
        public List<string> FlowerName { get; set; }
    }
}
