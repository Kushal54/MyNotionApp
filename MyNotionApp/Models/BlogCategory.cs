using System;
using System.Collections.Generic;

namespace MyNotionApp.Models
{
    public partial class BlogCategory
    {
        public int BlogCategoryId { get; set; }
        public int? UserId { get; set; }
        public string? CategoryName { get; set; }
    }
}
