using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MockAPI.Models.Requests
{
    public class DeleteAssetRequest
    {
        [DefaultValue("")]
        [Required]
        public string Id { get; set; }
    }
}
