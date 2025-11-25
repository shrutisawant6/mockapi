using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MockAPI.Models.Requests
{
    public class GetSpecificObjectRequest: BaseFilterObjectsRequest
    {
        [DefaultValue("1")]
        [Required]
        public int Id { get; set; }
    }
}
