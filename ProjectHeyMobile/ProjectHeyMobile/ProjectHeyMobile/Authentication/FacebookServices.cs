using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Authentication
{
    public class FacebookServices
    {

        public async Task<FacebookModel> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                ProjectHeyAuthentication.FacebookAPIEndpoint +
                "/me?" +
                "fields=" + ProjectHeyAuthentication.ScopeFields +
                "&access_token=" + accessToken;
                //"https://graph.facebook.com/v2.10/me?fields=first_name,last_name,birthday,about,gender,hometown,public_key,location,books{id,name},friends{id,first_name,last_name},email,movies{id,name},events{id,name},sports,albums{id,name},games{id,name},likes{id,name},music{id,name},relationship_status&access_token="
                //+ accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var facebookProfile = JsonConvert.DeserializeObject<FacebookModel>(userJson);

            return facebookProfile;
        }
        public async Task<FacebookPermissions> GetPermissions(FacebookModel facebookmodel, string accessToken)
        {
            var requestUrl =
                ProjectHeyAuthentication.FacebookAPIEndpoint +
                "/" + facebookmodel.id +
                "/permissions?access_token=" + accessToken;

            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(requestUrl);

            FacebookPermissions facebookpermissions = JsonConvert.DeserializeObject<FacebookPermissions>(response);

            return facebookpermissions;
        }
    }
}
