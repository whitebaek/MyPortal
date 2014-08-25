using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MyPortal.Controllers
{
    public class CommentController : Controller
    {
        private MyPortalContext db = new MyPortalContext();

        public ActionResult _GetForArticle(Int32 articleId)
        {
            ViewBag.ArticleId = articleId;
            List<Comment> comments = db.Comments.Where(c => c.ArticleId == articleId).ToList();

            return PartialView("_GetForArticle", comments);
        }

        [ChildActionOnly()]
        public ActionResult _CommentForm(Int32 articleId)
        {
            Comment comment = new Comment() { ArticleId = articleId };
            return PartialView("_CommentForm", comment);
        }

        [ValidateAntiForgeryToken()]
        public ActionResult _Submit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                //Defalut value 
                comment.CreatedDate = DateTime.Now;
                comment.UpdatedDate = DateTime.Now;
                // Instantiate the ASP.NET Identity system
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyPortalUserDbContext()));
                // Get the current logged in User and look up the user in ASP.NET Identity
                var currentUser = manager.FindById(User.Identity.GetUserId());
                comment.UserId = currentUser.MyUserInfo.Id;
                
                db.Comments.Add(comment);
                db.SaveChanges();
                List<Comment> comments = db.Comments.Where(c => c.ArticleId == comment.ArticleId).ToList();
                ViewBag.ArticleId = comment.ArticleId;

                return PartialView("_GetForArticle", comments);
            }
            return PartialView("_CommentForm", comment);
            
        }
	}
}