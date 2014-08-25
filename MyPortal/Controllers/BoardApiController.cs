using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MyPortal.Controllers
{
    public class BoardApiController : Controller
    {
        //
        // GET: /BoardApi/
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:4744/");
            
            // JSON 형식에 대한 Accept 헤더를 추가합니다.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/board").Result;  // 호출 블록킹!

            List<Article> articles = null; 
            if (response.IsSuccessStatusCode)
            {
                // 응답 본문 파싱. 블록킹!
                articles = response.Content.ReadAsAsync<List<Article>>().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
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
            
            Article article = GetArticleFromApi(id);
            
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        private Article GetArticleFromApi(int? id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:4744/");

            // JSON 형식에 대한 Accept 헤더를 추가합니다.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/board/" + id).Result;  // 호출 블록킹!
            
            Article article = null; 
            
            if (response.IsSuccessStatusCode)
            {
                // 응답 본문 파싱. 블록킹!
                article = response.Content.ReadAsAsync<Article>().Result;
            }

            return article;
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
        public ActionResult Create([Bind(Include = "ArticleId,Title,Content,Location,CreatedDate,UpdatedDate,UserId")] Article article)
        {
            if (ModelState.IsValid)
            {

                //Defalut value 
                article.CreatedDate = DateTime.Now;
                article.UpdatedDate = DateTime.Now;
                // Instantiate the ASP.NET Identity system
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyPortalUserDbContext()));
                // Get the current logged in User and look up the user in ASP.NET Identity
                var currentUser = manager.FindById(User.Identity.GetUserId());
                article.UserId = currentUser.MyUserInfo.Id;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:4744/");

                // JSON 형식에 대한 Accept 헤더를 추가합니다.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/board", article).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(article);
                }
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
            Article article = GetArticleFromApi(id);
            
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
        public ActionResult Edit([Bind(Include = "ArticleId,Title,Content,Location,CreatedDate,UpdatedDate,UserId")] Article article)
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

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:4744/");

                    // JSON 형식에 대한 Accept 헤더를 추가합니다.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync("api/board", article).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(article);
                    }
                }

            }
            return View(article);
        }
	}
}