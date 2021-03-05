using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Blog_App.Models
{
    public class blogAppContext : DbContext
    {
        public DbSet<blogModel> blogs { get; set; }
        public DbSet<blogComment> blogComments { get; set; }
    }
}