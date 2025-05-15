using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MockAPI.Models.Responses
{
    public class Asset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public AssetData? Data { get; set; } 

        //public JToken Data { get; set; }

        //public AssetData GetDataSafe() // this is done to handle a scenario for ids beyond a specific range and data is set to 0, irrespective of datatype
        //{
        //    if (Data?.Type == JTokenType.Object)
        //        return JsonConvert.DeserializeObject<AssetData>(Data.ToString());//Data.ToObject<AssetData>();

        //    return null;
        //}

        //public AssetData Data1 { 
        //    get; 
        //    set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public JToken Data { get; set; }

        public AssetData Details
        {
            get
            {
                if (Data?.Type == JTokenType.Object)
                {
                    return JsonConvert.DeserializeObject<AssetData>(Data.ToString());
                }

                return new AssetData();
            }
        }
    }
}
