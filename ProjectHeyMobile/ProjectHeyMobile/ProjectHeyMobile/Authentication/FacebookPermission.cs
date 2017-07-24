using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Authentication
{
    public class FacebookPermission
    {
        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
