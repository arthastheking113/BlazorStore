using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorStore.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Abstract { get; set; }
        [Required]
        public string Content { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Update Date")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "Product Ready?")]
        public bool IsproductionReady { get; set; }
        public string Slug { get; set; }

        [Display(Name = "Upload Image")]
        public Byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        [Display(Name = "View")]
        public int ViewCount { get; set; }

        //[Display(Name = "Comment")]
        //public int CountComment { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }


        [Display(Name = "Category")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Choose A Category")]
        public int BlogCategoryId { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }

        public virtual ICollection<BlogComment> PostComments { get; set; } = new HashSet<BlogComment>();
        public virtual ICollection<BlogTag> BlogTags { get; set; } = new HashSet<BlogTag>();
    }
}
