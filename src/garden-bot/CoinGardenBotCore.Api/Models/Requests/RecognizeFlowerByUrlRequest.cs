using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenBotCore_Api.Models.Requests {
    public class RecognizeFlowerByUrlRequest {

        public string contentType { get; set; }
        public string contentUrl { get; set; }
        public object content { get; set; }
        public string name { get; set; }
        public object thumbnailUrl { get; set; }
    }
}
