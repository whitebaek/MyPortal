using MyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace MyPortal.Controllers.Api
{
    public class Board2Controller : ApiController
    {
        ////
        // Pagination 
        public HttpResponseMessage GetArticles(int page = 0, int pageSize = 10)
        {
            IQueryable<Article> query;

            MyPortalContext ctx = new MyPortalContext();
            query = ctx.Articles.OrderBy(a => a.CreatedDate);

            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var urlHelper = new UrlHelper(Request);
            var prevLink = page > 0 ? urlHelper.Link("DefaultApi", new { page = page - 1, pageSize = pageSize }) : "";
            var nextLink = page < totalPages - 1 ? urlHelper.Link("DefaultApi", new { page = page + 1, pageSize = pageSize }) : "";

            var results = query
                          .Skip(pageSize * page)
                          .Take(pageSize)
                          .ToList();

            var result = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                PrevPageLink = prevLink,
                NextPageLink = nextLink,
                Results = results
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("~/api/article/{articleId:int}/comments")]
        public HttpResponseMessage GetCommentsByArticle(int ArticleId)
        {
            MyPortalContext ctx = null;

            IQueryable<Comment> query;

            try
            {
                ctx = new MyPortalContext();

                query = ctx.Comments.Where(c => c.ArticleId == ArticleId);
                var commentsList = query.Select(c => c.Content).ToList();
                if (commentsList != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, commentsList);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            finally
            {
                ctx.Dispose();
            }
        }

        [Route("{id:int}")]
        //[DisableCors()]
        public IHttpActionResult GetArticle(int id)
        {

            MyPortalContext ctx = null;

            try
            {

                ctx = new MyPortalContext();

                var article = ctx.Articles.Find(id);
                if (article != null)
                {
                    return Ok<MyPortal.Models.Article>(article);
                }
                else
                {
                    return NotFound(); 
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            finally
            {
                ctx.Dispose();
            }
        }
    }
}
