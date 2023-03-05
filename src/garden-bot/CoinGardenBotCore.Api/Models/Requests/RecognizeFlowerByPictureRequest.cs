using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenBotCore_Api.Models.Requests {
    public class RecognizeFlowerByPictureRequest {
        /// <summary>
        /// Gets or sets the additional metadata to pass to server.
        /// </summary>
        [OpenApiProperty(Description = "Additional data to pass to server")]
        public string AdditionalMetadata { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="byte[]"/> value representing file to upload.
        /// </summary>
        [OpenApiProperty(Description = "File to upload")]
        public byte[] File { get; set; }
    }
}
