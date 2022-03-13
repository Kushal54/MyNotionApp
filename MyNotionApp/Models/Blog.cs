using System;
using System.Collections.Generic;

namespace MyNotionApp.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public int? BlogCategoryId { get; set; }
        public int? UserId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogDescription { get; set; }
        public string? BlogBody { get; set; }
        public int? Likes { get; set; }
    }
}
