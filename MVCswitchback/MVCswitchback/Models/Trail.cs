using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models
{

    public class Rootobject
    {
        public Trail[] trails { get; set; }
        public int success { get; set; }
    }

    public class Trail
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("summary")]
        public string summary { get; set; }
        [JsonProperty("difficulty")]
        public string difficulty { get; set; }
        [JsonProperty("stars")]
        public float stars { get; set; }
        [JsonProperty("starVotes")]
        public int starVotes { get; set; }
        [JsonProperty("location")]
        public string location { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("imgSqSmall")]
        public string imgSqSmall { get; set; }
        [JsonProperty("imgSmall")]
        public string imgSmall { get; set; }
        [JsonProperty("imgSmallMed")]
        public string imgSmallMed { get; set; }
        [JsonProperty("imgMedium")]
        public string imgMedium { get; set; }
        [JsonProperty("length")]
        public float length { get; set; }
        [JsonProperty("ascent")]
        public int ascent { get; set; }
        [JsonProperty("descent")]
        public int descent { get; set; }
        [JsonProperty("high")]
        public int high { get; set; }
        [JsonProperty("low")]
        public int low { get; set; }
        [JsonProperty("longitude")]
        public float longitude { get; set; }
        [JsonProperty("latitude")]
        public float latitude { get; set; }
        [JsonProperty("conditionStatus")]
        public string conditionStatus { get; set; }
        [JsonProperty("conditionDetails")]
        public string conditionDetails { get; set; }
        [JsonProperty("conditionDate")]
        public string conditionDate { get; set; }
    }
}
