using MockAPI.DTOs.Response;
using MockAPI.Models.Responses;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MockAPI.Models.Requests
{
    //same object can be used for add/update/partial update
    public class ManageAssetRequest
    {
        [DefaultValue("Test Object")]
        [Required]
        public string Name { get; set; }

        public AssetData Data { get; set; }
    }
}
