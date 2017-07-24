using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Authentication
{
    public class FacebookPermissions
    {
        [JsonProperty(PropertyName = "data")]
        public List<FacebookPermission> Permissions { get; set; }

    }
}
