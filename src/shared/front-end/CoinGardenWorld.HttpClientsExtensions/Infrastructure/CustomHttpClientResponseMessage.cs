//---------------------------------------------------------------------
// <copyright file="HttpClientResponseMessage.cs" company=".NET Foundation">
//      Copyright (c) .NET Foundation and Contributors. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

using Microsoft.OData;
using Microsoft.OData.Client;
using Microsoft.OData.Extensions.Client.Internals.Handlers;

namespace CoinGardenWorld.HttpClientsExtensions.Infrastructure
{
    internal class CustomHttpClientResponseMessage : HttpWebResponseMessage, IODataResponseMessage
    {
        public CustomHttpClientResponseMessage(HttpResponseMessage httpResponse, DataServiceClientConfigurations config)
            : base(httpResponse.ToStringDictionary(),
                (int)httpResponse.StatusCode,
                () => { var task = httpResponse.Content.ReadAsStreamAsync(); task.Wait(); return task.Result; })
        {
        }


    }
}