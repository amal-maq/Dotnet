using System;
using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
