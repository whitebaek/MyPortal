using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace MyPortal.Controllers
{
    public class BoardController : Controller
    {
        private MyPortalContext db = new MyPortalContext();

        // GET: /Board/
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        //Use Webaip
        // GET: /Board/
        public ActionResult Index2()
        {

            string apiURL = "http://localhost:4744/api/board/";

            List<Article> articles = new List<Article>();
            using (WebClient webClient = new WebClient())
            {
                string dwml;
                dwml = webClient.DownloadString(apiURL);
                articles = JsonConvert.DeserializeObjectAsync<List<Article>>(dwml).Result;
            }
            return View(articles);
        }

        //Use oData
        // GET: /Board/
        public ActionResult Index3()
        {

            string apiURL = "http://localhost:4744/api/board/";

            List<Article> articles = new List<Article>();
            using (WebClient webClient = new WebClient())
            {
                string dwml;
                dwml = webClient.DownloadString(apiURL);
                articles = JsonConvert.DeserializeObjectAsync<List<Article>>(dwml).Result;
            }
            return View(articles);
        }

        // GET: /Board/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: /Board/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Board/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ArticleId,Title,Content,Location,CreatedDate,UpdatedDate,UserId")] Article article)
        {
            if (ModelState.IsValid)
            {
                //Defalut value 
                article.CreatedDate = DateTime.Now;
                article.UpdatedDate= DateTime.Now;
                // Instantiate the ASP.NET Identity system
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyPortalUserDbContext()));
                // Get the current logged in User and look up the user in ASP.NET Identity
                var currentUser = manager.FindById(User.Identity.GetUserId());
                article.UserId = currentUser.MyUserInfo.Id;

                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: /Board/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: /Board/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ArticleId,Title,Content,Location,CreatedDate,UpdatedDate,UserId")] Article article)
        {
            if (ModelState.IsValid)
            {
                // Instantiate the ASP.NET Identity system
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyPortalUserDbContext()));
                // Get the current logged in User and look up the user in ASP.NET Identity
                var currentUser = manager.FindById(User.Identity.GetUserId());
                if (article.UserId == currentUser.MyUserInfo.Id)
                {
                    //Defalut value 
                    article.CreatedDate = article.CreatedDate;
                    article.UpdatedDate = DateTime.Now;

                    article.UserId = currentUser.MyUserInfo.Id;
                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            return View(article);
        }

        // GET: /Board/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: /Board/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);

            // Instantiate the ASP.NET Identity system
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyPortalUserDbContext()));
            // Get the current logged in User and look up the user in ASP.NET Identity
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (article.UserId == currentUser.MyUserInfo.Id)
            {
                db.Articles.Remove(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
