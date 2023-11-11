//---------------------------------------------------------------------
// <copyright file="HttpHeadersExtensions.cs" company=".NET Foundation">
//      Copyright (c) .NET Foundation and Contributors. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Microsoft.OData.Extensions.Client.Internals.Handlers
{
    internal static class HttpHeadersExtensions
    {
        public static IDictionary<string, string> ToStringDictionary(this HttpHeaders headers)
        {
            return headers.ToDictionary((h1) => h1.Key, (h2) => string.Join(",", h2.Value));
        }

        public static IDictionary<string, string> ToStringDictionary(this HttpResponseMessage message)
        {
            if (message.Content != null)
            {
                var dic = message.Headers.ToStringDictionary();
                foreach (var item in message.Content.Headers.ToStringDictionary())
                {
                    dic[item.Key] = item.Value;
                }

                return dic;
            }

            return message.Headers.ToStringDictionary();
        }
    }
}