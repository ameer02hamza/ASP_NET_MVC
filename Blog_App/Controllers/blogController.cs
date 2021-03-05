using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Blog_App.Models;
using Blog_App.viewModel;

namespace Blog_App.Controllers
{
    public class blogController : Controller
    {
        private blogAppContext _context;
        public blogController()
        {
            _context = new blogAppContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: blog
        public ActionResult blogView()
        {
            var blog_data = _context.blogs.Include(b => b.blogComment).ToList();
           
            return View(blog_data);
        }
        public ActionResult detailView(int id)
        {
            var blogDetail = _context.blogs.Include(b => b.blogComment).SingleOrDefault(x => x.blogId == id);
            if (blogDetail == null)
            {
                return HttpNotFound();
            }
            System.Diagnostics.Debug.WriteLine(id);
            return View(blogDetail);
        }
        
        public ActionResult createBlog(int? id, blogModel AddBlog)
        {
            var blog = _context.blogs.Find(id);
            //if (blog != null)
            //{
            //    System.Diagnostics.Debug.WriteLine("update function");
            //}
            //else
            //{
            //    System.Diagnostics.Debug.WriteLine("date function");
            //    _context.blogs.Add(AddBlog);
            //    System.Diagnostics.Debug.WriteLine("Done");
               
            //}
            
            return View(blog);
        }

        public ActionResult Save(blogModel blogm)
        {
            var blog = _context.blogs.Find(blogm.blogId);
            if (blog != null)
            {
                blog.blogTitle = blogm.blogTitle;
                blog.blogText = blogm.blogText;
                System.Diagnostics.Debug.WriteLine("update function", blogm.blogId);
                System.Diagnostics.Debug.WriteLine("id dd", blogm.blogId);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("date function");
                _context.blogs.Add(blogm);
                System.Diagnostics.Debug.WriteLine("Done");

            }
            _context.SaveChanges();
            return RedirectToAction("blogView", "blog");
        }
        public ActionResult Delete(int? id)
        {
            System.Diagnostics.Debug.WriteLine("fsfsfs", id);
            var blog = _context.blogs.Find(id);
            _context.blogs.Remove(blog);
            _context.SaveChanges();
            return HttpNotFound();
        }
      
    }
}