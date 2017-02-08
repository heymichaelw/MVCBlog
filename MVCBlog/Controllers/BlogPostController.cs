using MVCBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class BlogPostController : Controller
    {

        private BlogPostContext db = new BlogPostContext();

        // GET: BlogPost
        public ActionResult Index()
        {
            return View(db.BlogPosts.ToList());
        }

        [HttpPost]
        public ActionResult Create(BlogPost blogPost)
        {
            blogPost.Created = DateTime.Now;
            db.BlogPosts.Add(blogPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            BlogPost blog = db.BlogPosts.First(b => b.Id == id);
            return View(blog);
        }
    }
}