using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.AzureStorageClientsExtensions
{
    public interface IBlobStorageService
    {
        Task<string> UploadFileToBlobAsync(string blobContainerName, string strFileName, string contecntType, Stream fileStream);
        Task<bool> DeleteFileToBlobAsync(string blobContainerName, string strFileName);
    }
}
