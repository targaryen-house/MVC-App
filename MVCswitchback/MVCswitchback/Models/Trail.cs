using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models
{

    //public class Rootobject
    //{
    //    public Trail[] Trails { get; set; }
    //    public int Success { get; set; }
    //}

    //public class Trail
    //{
    //    [JsonProperty("id")]
    //    public int ID { get; set; }
    //    [JsonProperty("name")]
    //    public string Name { get; set; }
    //    [JsonProperty("type")]
    //    public string Type { get; set; }
    //    [JsonProperty("summary")]
    //    public string Summary { get; set; }
    //    [JsonProperty("difficulty")]
    //    public string Difficulty { get; set; }
    //    [JsonProperty("stars")]
    //    public float Stars { get; set; }
    //    [JsonProperty("starVotes")]
    //    public int StarVotes { get; set; }
    //    [JsonProperty("location")]
    //    public string Location { get; set; }
    //    [JsonProperty("url")]
    //    public string Url { get; set; }
    //    [JsonProperty("imgSqSmall")]
    //    public string ImgSqSmall { get; set; }
    //    [JsonProperty("imgSmall")]
    //    public string ImgSmall { get; set; }
    //    [JsonProperty("imgSmallMed")]
    //    public string ImgSmallMed { get; set; }
    //    [JsonProperty("imgMedium")]
    //    public string ImgMedium { get; set; }
    //    [JsonProperty("length")]
    //    public float Length { get; set; }
    //    [JsonProperty("ascent")]
    //    public int Ascent { get; set; }
    //    [JsonProperty("descent")]
    //    public int Descent { get; set; }
    //    [JsonProperty("high")]
    //    public int High { get; set; }
    //    [JsonProperty("low")]
    //    public int Low { get; set; }
    //    [JsonProperty("longitude")]
    //    public float Longitude { get; set; }
    //    [JsonProperty("latitude")]
    //    public float Latitude { get; set; }
    //    [JsonProperty("conditionStatus")]
    //    public string ConditionStatus { get; set; }
    //    [JsonProperty("conditionDetails")]
    //    public string ConditionDetails { get; set; }
    //    [JsonProperty("conditionDate")]
    //    public string ConditionDate { get; set; }
    //}


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
        public string Name { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Summary")]
        public string Summary { get; set; }
        [JsonProperty("Difficulty")]
        public string Difficulty { get; set; }
        [JsonProperty("Stars")]
        public float Stars { get; set; }
        [JsonProperty("StarVotes")]
        public int StarVotes { get; set; }
        [JsonProperty("Location")]
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
