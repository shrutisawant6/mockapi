using MockAPI.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace MockAPI.DTOs.Response
{
    public class AssetDto
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        //public AssetDataDto Data { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public JToken Data { get; set; }

        public AssetDataDto Details
        {
            get
            {
                if (Data?.Type == JTokenType.Object)
                {
                    return JsonConvert.DeserializeObject<AssetDataDto>(Data.ToString());
                }

                return new AssetDataDto();
            }
        }
    }
}
