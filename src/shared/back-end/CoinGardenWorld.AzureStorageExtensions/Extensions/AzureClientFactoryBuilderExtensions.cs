using Azure.Core.Extensions;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Queues;
using Microsoft.Extensions.Azure;

namespace CoinGardenWorld.AzureStorageExtensions.Extensions
{
    public static class AzureClientFactoryBuilderExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddCgwBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri? serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }

        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddCgwQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri? serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }

        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddCgwFileServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri? serviceUri))
            {
                return builder.AddFileServiceClient(serviceUri);
            }
            else
            {
                return builder.AddFileServiceClient(serviceUriOrConnectionString);
            }
        }
    }
}