using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MyPortal.Models;
using System.Web.Http.Routing;

namespace MyPortal.Controllers.Api
{
    public class BoardController : ApiController
    {
        private MyPortalContext db = new MyPortalContext();

        // GET api/Board
        public IQueryable<Article> GetArticles()
        {
            return db.Articles.Include(a=>a.Comments);
        }


        // GET api/Board/5
        [ResponseType(typeof(Article))]
        public async Task<IHttpActionResult> GetArticle(int id)
        {
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT api/Board/5
        public async Task<IHttpActionResult> PutArticle(int id, Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.ArticleId)
            {
                return BadRequest();
            }

            db.Entry(article).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Board
        [ResponseType(typeof(Article))]
        public async Task<IHttpActionResult> PostArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            article.UpdatedDate = DateTime.Now;
            article.CreatedDate = DateTime.Now;

            db.Articles.Add(article);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = article.ArticleId }, article);
        }

        // DELETE api/Board/5
        [ResponseType(typeof(Article))]
        public async Task<IHttpActionResult> DeleteArticle(int id)
        {
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            db.Articles.Remove(article);
            await db.SaveChangesAsync();

            return Ok(article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticleExists(int id)
        {
            return db.Articles.Count(e => e.ArticleId == id) > 0;
        }

    }
}