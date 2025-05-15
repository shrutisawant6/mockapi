﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MockAPI.Models.Requests
{
    [CompareProperties("PageSize", "PageNumber")]
    public class FilterObjectsRequest
    {
        [DefaultValue("")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Search { get; set; }

        [DefaultValue("1")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "PageNumber must be at least 1.")]
        public int PageNumber { get; set; }

        [DefaultValue("10")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "PageSize must be at least 1.")]
        public int PageSize { get; set; }
    }
}
