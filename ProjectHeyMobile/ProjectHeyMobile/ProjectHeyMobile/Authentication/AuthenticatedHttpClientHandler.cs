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
             //<<Custom Authorization>>>
            //string signature = GetSignature(request);
            //string timeSigned = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
            //request.Headers.Authorization = new AuthenticationHeaderValue("Authorization", signature);
            //request.Headers.Add(AWS4SignerBase.X_Amz_Content_SHA256, AWS4SignerBase.EMPTY_BODY_SHA256);
            //request.Headers.Add("X-Amz-Date", timeSigned);
            // SET BREAKPOINT OTHERWISE IT KEEPS LOADING, Let's fix 1 problem at the time.
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false); 
        }
        private string GetSignature(HttpRequestMessage request)
        {
            // for a simple GET, we have no body so supply the precomputed 'empty' hash
            var headers = new Dictionary<string, string>
                {
                    {AWS4SignerBase.X_Amz_Content_SHA256, AWS4SignerBase.EMPTY_BODY_SHA256}
                    //{"content-type", "text/plain"}
                };

            var signer = new AWS4SignerForAuthorizationHeader
            {
                EndpointUri = new Uri(request.RequestUri.AbsoluteUri),
                HttpMethod = request.Method.ToString(),
                Service = "execute-api",
                Region = "eu-west-2"
            };

            string signature = signer.ComputeSignature(headers,
                                                            request.RequestUri.Query.ToString(),
                                                            AWS4SignerBase.EMPTY_BODY_SHA256,
                                                            ProjectHeyAuthentication.AWSAccessKey,
                                                            ProjectHeyAuthentication.AWSSecretKey);
            return signature;
        }

    }
}
