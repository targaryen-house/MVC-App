using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models
{
    public class Rootobject
    {
        public Trail[] Trails { get; set; }
    }

    public class Trail
    {
        [JsonProperty("trailID")]
        public int TrailID { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Summary")]
        [DataType(DataType.Text)]
        public string Summary { get; set; }
        [JsonProperty("Difficulty")]
        [DataType(DataType.Text)]
        public string Difficulty { get; set; }
        [JsonProperty("Stars")]
        public float Stars { get; set; }
        [JsonProperty("StarVotes")]
        public int StarVotes { get; set; }
        [JsonProperty("Location")]
        [DataType(DataType.Text)]
        public string Location { get; set; }
        [JsonProperty("URL")]
        public string URL { get; set; }
        [JsonProperty("ImgSqSmall")]
        public string ImgSqSmall { get; set; }
        [JsonProperty("ImgSmall")]
        public string ImgSmall { get; set; }
        [JsonProperty("ImgSmallMed")]
        public string ImgSmallMed { get; set; }
        [JsonProperty("ImgMedium")]
        public string ImgMedium { get; set; }
        [JsonProperty("Length")]
        [DataType(DataType.Text)]
        public float Length { get; set; }
        [JsonProperty("Ascent")]
        public int Ascent { get; set; }
        [JsonProperty("Descent")]
        public int Descent { get; set; }
        [JsonProperty("High")]
        public int High { get; set; }
        [JsonProperty("Low")]
        public int Low { get; set; }
        [JsonProperty("Longitude")]
        public float Longitude { get; set; }
        [JsonProperty("Latitude")]
        public float Latitude { get; set; }
        [JsonProperty("ConditionStatus")]
        public string ConditionStatus { get; set; }
        [JsonProperty("ConditionDetails")]
        public string ConditionDetails { get; set; }
        [JsonProperty("ConditionDate")]
        public string ConditionDate { get; set; }
        [JsonProperty("UserRatings")]
        public object UserRatings { get; set; }
    }




}
