using CoinGardenBotCore_Api.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenBotCore_Api.Models.Responses {
    public class RecognizedFlowerResponse {
        public List<RecognizedFlowerModel> RecognizedFlowers { get; set; }
    }
}
