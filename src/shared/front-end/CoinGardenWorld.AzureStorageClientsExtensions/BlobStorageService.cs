
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Configuration;

namespace CoinGardenWorld.AzureStorageClientsExtensions
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BlobStorageService> _logger;
        string blobStorageconnection = string.Empty;
        public BlobStorageService(IConfiguration configuration, ILogger<BlobStorageService> logger)
        {
            _configuration = configuration;
            _logger = logger;
            blobStorageconnection = _configuration.GetConnectionString("CGW-AzureStorageMobileApp");
        }
        public async Task<string> UploadFileToBlobAsync(string blobContainerName, string strFileName, string contentType, Stream fileStream)
        {
            try
            { 
                var container = new BlobContainerClient(blobStorageconnection, blobContainerName);
                var createResponse = await container.CreateIfNotExistsAsync();
                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

                var blob = container.GetBlobClient(strFileName);
                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });
                var urlString = blob.Uri.ToString();
                return urlString;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                throw;
            }
        }
        public async Task<bool> DeleteFileToBlobAsync(string blobContainerName, string strFileName)
        {
            try
            {
                var container = new BlobContainerClient(blobStorageconnection, blobContainerName);
                var createResponse = await container.CreateIfNotExistsAsync();
                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                var blob = container.GetBlobClient(strFileName);
                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                return true;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                throw;
            }
        }
    }
}
