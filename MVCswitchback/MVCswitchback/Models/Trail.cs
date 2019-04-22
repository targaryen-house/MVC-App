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
        [JsonProperty("TrailID")]
        public int TrailID { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Summary")]
        [Required]
        [DataType(DataType.Text)]
        public string Summary { get; set; }
        [JsonProperty("Difficulty")]
        [Required]
        [DataType(DataType.Text)]
        public string Difficulty { get; set; }
        [JsonProperty("Stars")]
        [Required]
        public float Stars { get; set; }
        [JsonProperty("StarVotes")]
        public int StarVotes { get; set; }
        [JsonProperty("Location")]
        [Required]
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
        [Required]
        [DataType(DataType.Text)]
        public float Length { get; set; }
        [JsonProperty("Ascent")]
        [Required]
        public int Ascent { get; set; }
        [JsonProperty("Descent")]
        [Required]
        public int Descent { get; set; }
        [JsonProperty("High")]
        [Required]
        public int High { get; set; }
        [JsonProperty("Low")]
        [Required]
        public int Low { get; set; }
        [JsonProperty("Longitude")]
        [Required]
        public float Longitude { get; set; }
        [JsonProperty("Latitude")]
        [Required]
        public float Latitude { get; set; }
        [JsonProperty("ConditionStatus")]
        [Required]
        public string ConditionStatus { get; set; }
        [JsonProperty("ConditionDetails")]
        [Required]
        public string ConditionDetails { get; set; }
        [JsonProperty("ConditionDate")]
        [Required]
        public string ConditionDate { get; set; }
        [JsonProperty("UserRatings")]
        public object UserRatings { get; set; }
    }




}
