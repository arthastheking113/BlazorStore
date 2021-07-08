using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class BlogTag
    {
        public int Id { get; set; }
        [Display(Name = "Tag Name")]
        [Required]
        public string TagName { get; set; }

        public virtual ICollection<BlogPost> PostCategories { get; set; } = new HashSet<BlogPost>();
    }
}
