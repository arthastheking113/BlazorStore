using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class ItemAttachment
    {
        public int Id { get; set; }

        [Display(Name = "Upload Image")]
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        public string Link { get; set; }

        public int ItemAttachmentTypeId { get; set; }
        public virtual ItemAttachmentType ItemAttachmentType { get; set; }

        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
