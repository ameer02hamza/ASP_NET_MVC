using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog_App.Models
{
    public class blogModel
    {
        [Key]
        public int blogId { get; set; }

        public string blogTitle { get; set; }
        
        public string blogText { get; set; }

        public DateTime blogCreated { get; set; }

        public blogComment blogComment { get; set; }


    }
}