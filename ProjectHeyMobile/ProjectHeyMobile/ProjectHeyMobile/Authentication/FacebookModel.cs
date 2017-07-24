using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Authentication
{
    public class FacebookModel
    {
        [JsonProperty(PropertyName = "first_name")]
        public string first_name { get; set; }
        [JsonProperty(PropertyName = "last_name")]
        public string last_name { get; set; }
        [JsonProperty(PropertyName = "birthday")]
        public string birthday { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public string gender { get; set; }
        [JsonProperty(PropertyName = "location")]
        public Location location { get; set; }
        [JsonProperty(PropertyName = "friends")]
        public Friends friends { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }
        [JsonProperty(PropertyName = "events")]
        public Events events { get; set; }
        [JsonProperty(PropertyName = "games")]
        public Games games { get; set; }
        [JsonProperty(PropertyName = "likes")]
        public Likes likes { get; set; }
        [JsonProperty(PropertyName = "music")]
        public Music music { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
    }

    public class Location : FBOjectMinInfo
    {
    }

    public class Summary
    {
        [JsonProperty(PropertyName = "total_count")]
        public int total_count { get; set; }
    }

    public class Friends
    {
        [JsonProperty(PropertyName = "data")]
        public List<Friend> data { get; set; }
        [JsonProperty(PropertyName = "summary")]
        public Summary summary { get; set; }
    }
    public class Friend : FBOjectMinInfo
    {

    }
    public class FBOjectMinInfo
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
    }

    public class Cursors
    {
        [JsonProperty(PropertyName = "before")]
        public string before { get; set; }
        [JsonProperty(PropertyName = "after")]
        public string after { get; set; }
    }

    public class Paging
    {
        [JsonProperty(PropertyName = "cursors")]
        public Cursors cursors { get; set; }
        [JsonProperty(PropertyName = "next")]
        public string next { get; set; }
    }

    public class Events
    {
        [JsonProperty(PropertyName = "data")]
        public List<object> data { get; set; }
        [JsonProperty(PropertyName = "paging")]
        public Paging paging { get; set; }
    }

    public class Games
    {
        [JsonProperty(PropertyName = "data")]
        public List<Game> data { get; set; }
        [JsonProperty(PropertyName = "paging")]
        public Paging paging { get; set; }
    }
    public class Game : FBOjectMinInfo
    {

    }

    public class Likes
    {
        [JsonProperty(PropertyName = "data")]
        public List<Like> data { get; set; }
        [JsonProperty(PropertyName = "paging")]
        public Paging paging { get; set; }
    }

    public class Like : FBOjectMinInfo
    {

    }
    public class Music
    {
        [JsonProperty(PropertyName = "data")]
        public List<MusicInfo> data { get; set; }
        [JsonProperty(PropertyName = "paging")]
        public Paging paging { get; set; }
    }
    public class MusicInfo : FBOjectMinInfo
    {

    }
}

