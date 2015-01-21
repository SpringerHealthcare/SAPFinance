using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using SAPFinanceODataService.Models;
using SAPFinanceODataService.DataAccess;

namespace SAPFinanceODataService.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.
    */
    public class ArticlesController : ODataController
    {
        private QuotesContext db = new QuotesContext();

        // GET odata/Articles
        [EnableQuery]
        public IQueryable<vw_SAPFinance_Articles> GetArticles()
        {
            return db.vw_SAPFinance_Articles;
        }

        // GET odata/Articles(5)
        [EnableQuery]
        public SingleResult<vw_SAPFinance_Articles> Getvw_SAPFinance_Articles([FromODataUri] int key)
        {
            return SingleResult.Create(db.vw_SAPFinance_Articles.Where(vw_sapfinance_articles => vw_sapfinance_articles.article_id == key));
        }

        // PUT odata/Articles(5)
        public IHttpActionResult Put([FromODataUri] int key, vw_SAPFinance_Articles vw_sapfinance_articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != vw_sapfinance_articles.article_id)
            {
                return BadRequest();
            }

            db.Entry(vw_sapfinance_articles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vw_SAPFinance_ArticlesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(vw_sapfinance_articles);
        }

        // POST odata/Articles
        public IHttpActionResult Post(vw_SAPFinance_Articles vw_sapfinance_articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vw_SAPFinance_Articles.Add(vw_sapfinance_articles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vw_SAPFinance_ArticlesExists(vw_sapfinance_articles.article_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(vw_sapfinance_articles);
        }

        // PATCH odata/Articles(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<vw_SAPFinance_Articles> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vw_SAPFinance_Articles vw_sapfinance_articles = db.vw_SAPFinance_Articles.Find(key);
            if (vw_sapfinance_articles == null)
            {
                return NotFound();
            }

            patch.Patch(vw_sapfinance_articles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vw_SAPFinance_ArticlesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(vw_sapfinance_articles);
        }

        // DELETE odata/Articles(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            vw_SAPFinance_Articles vw_sapfinance_articles = db.vw_SAPFinance_Articles.Find(key);
            if (vw_sapfinance_articles == null)
            {
                return NotFound();
            }

            db.vw_SAPFinance_Articles.Remove(vw_sapfinance_articles);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vw_SAPFinance_ArticlesExists(int key)
        {
            return db.vw_SAPFinance_Articles.Count(e => e.article_id == key) > 0;
        }
    }
}
