using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MockAPI.Models.Requests
{
    public class BaseFilterObjectsRequest
    {
        [DefaultValue("")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Search { get; set; }
    }
}
