using System.ComponentModel.DataAnnotations;

namespace MockAPI.Models.Responses
{
    //[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class AssetData
    {
        [Required]
        public string Color { get; set; }

        [Required]
        public string Capacity { get; set; }

        public int? CapacityGB { get; set; }
        public double? Price { get; set; }

        [Required]
        public string Generation { get; set; }
        public int? Year { get; set; }

        [Required]
        public string CpuModel { get; set; }

        [Required]
        public string HardDiskSize { get; set; }

        [Required]
        public string StrapColour { get; set; }

        [Required]
        public string CaseSize { get; set; }

        [Required]
        public string Description { get; set; }

        public double? ScreenSize { get; set; }
    }
}
