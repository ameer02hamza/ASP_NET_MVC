using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_App.Models
{
    public class blogComment
    {
        [Key]
        public int commentId { get; set; }
        public string Comment { get; set; }    }
}