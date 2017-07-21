using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using ProjectHeyMobile.Authentication.Signers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Authentication
{
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        public AuthenticatedHttpClientHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                // for a simple GET, we have no body so supply the precomputed 'empty' hash
                var headers = new Dictionary<string, string>
                {
                    {AWS4SignerBase.X_Amz_Content_SHA256, AWS4SignerBase.EMPTY_BODY_SHA256}
                    //{"content-type", "text/plain"}
                };

                var signer = new AWS4SignerForAuthorizationHeader
                {
                    EndpointUri = request.RequestUri,
                    HttpMethod = "GET",
                    Service = "execute-api",
                    Region = "eu-west-2"
                };

                var authorization = signer.ComputeSignature(headers,
                                                            request.RequestUri.Query.ToString(),
                                                            AWS4SignerBase.EMPTY_BODY_SHA256,
                                                            ProjectHeyAuthentication.AWSAccessKey,
                                                            ProjectHeyAuthentication.AWSSecretKey);

                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, authorization);
                request.Headers.Add(AWS4SignerBase.X_Amz_Content_SHA256, AWS4SignerBase.EMPTY_BODY_SHA256);
                string time = DateTime.UtcNow.ToString("yyyy-MM-ddTH:mm:ss");
                request.Headers.Add("X-Amz-Date", time);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

    }
}
