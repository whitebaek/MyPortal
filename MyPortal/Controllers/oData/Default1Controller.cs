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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using MyPortal.Models;

namespace MyPortal.Controllers.oData
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using MyPortal.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Article>("Default1");
    builder.EntitySet<Comment>("Comment"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class Default1Controller : ODataController
    {
        private MyPortalContext db = new MyPortalContext();

        // GET odata/Default1
        [Queryable]
        public IQueryable<Article> GetDefault1()
        {
            return db.Articles;
        }

        // GET odata/Default1(5)
        [Queryable]
        public SingleResult<Article> GetArticle([FromODataUri] int key)
        {
            return SingleResult.Create(db.Articles.Where(article => article.ArticleId == key));
        }

        // PUT odata/Default1(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != article.ArticleId)
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
                if (!ArticleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(article);
        }

        // POST odata/Default1
        public async Task<IHttpActionResult> Post(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articles.Add(article);
            await db.SaveChangesAsync();

            return Created(article);
        }

        // PATCH odata/Default1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Article> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Article article = await db.Articles.FindAsync(key);
            if (article == null)
            {
                return NotFound();
            }

            patch.Patch(article);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(article);
        }

        // DELETE odata/Default1(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Article article = await db.Articles.FindAsync(key);
            if (article == null)
            {
                return NotFound();
            }

            db.Articles.Remove(article);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Default1(5)/Comments
        [Queryable]
        public IQueryable<Comment> GetComments([FromODataUri] int key)
        {
            return db.Articles.Where(m => m.ArticleId == key).SelectMany(m => m.Comments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticleExists(int key)
        {
            return db.Articles.Count(e => e.ArticleId == key) > 0;
        }
    }
}
