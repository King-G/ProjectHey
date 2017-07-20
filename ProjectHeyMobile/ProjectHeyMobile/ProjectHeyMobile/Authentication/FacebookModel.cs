using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Authentication
{
    public class FacebookModel
    {
        public AgeRange age_range { get; set; }
        public string birthday { get; set; }
        public Context context { get; set; }
        public Cover cover { get; set; }
        public string created_at { get; set; }
        public List<Device> devices { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public string family_name { get; set; }
        public string gender { get; set; }
        public string given_name { get; set; }
        public List<Identity> identities { get; set; }
        public bool installed { get; set; }
        public bool is_verified { get; set; }
        public string last_ip { get; set; }
        public string last_login { get; set; }
        public string link { get; set; }
        public string locale { get; set; }
        public Location location { get; set; }
        public int logins_count { get; set; }
        public string name { get; set; }
        public string name_format { get; set; }
        public string nickname { get; set; }
        public string picture { get; set; }
        public string picture_large { get; set; }
        public string third_party_id { get; set; }
        public int timezone { get; set; }
        public string updated_at { get; set; }
        public string updated_time { get; set; }
        public string user_id { get; set; }
        public bool verified { get; set; }
    }

    public class AgeRange
    {
        public int min { get; set; }
    }

    public class Summary
    {
        public int total_count { get; set; }
    }

    public class MutualFriends
    {
        public List<object> data { get; set; }
        public Summary summary { get; set; }
    }

    public class Datum
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
        public string next { get; set; }
    }

    public class Summary2
    {
        public int total_count { get; set; }
    }

    public class MutualLikes
    {
        public List<Datum> data { get; set; }
        public Paging paging { get; set; }
        public Summary2 summary { get; set; }
    }

    public class Context
    {
        public MutualFriends mutual_friends { get; set; }
        public MutualLikes mutual_likes { get; set; }
        public string id { get; set; }
    }

    public class Cover
    {
        public string id { get; set; }
        public int offset_x { get; set; }
        public int offset_y { get; set; }
        public string source { get; set; }
    }

    public class Device
    {
        public string os { get; set; }
    }

    public class Identity
    {
        public string provider { get; set; }
        public string user_id { get; set; }
        public string connection { get; set; }
        public bool isSocial { get; set; }
    }

    public class Location
    {
        public string id { get; set; }
        public string name { get; set; }
    }


}
