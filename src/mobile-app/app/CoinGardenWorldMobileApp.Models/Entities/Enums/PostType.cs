using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.Entities.Enums
{
    public enum PostType
    {
        // No links no images, just plain text may be with some hash tags 
        Text,
        // External link if any in the text
        Link,
        // Single image
        Picture,
        // Single video
        Video,
        // Album is combination of pictures and videos
        Album



    }
}
