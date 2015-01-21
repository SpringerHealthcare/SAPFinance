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
    public class SolicitationQuotesController : ODataController
    {
        private QuotesContext db = new QuotesContext();

        // GET odata/SolicitationQuotes
        [EnableQuery]
        public IQueryable<tbl_Solicitation_Quotes> GetSolicitationQuotes()
        {
            return db.tbl_Solicitation_Quotes;
        }

        // GET odata/SolicitationQuotes(5)
        [EnableQuery]
        public SingleResult<tbl_Solicitation_Quotes> Gettbl_Solicitation_Quotes([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_Solicitation_Quotes.Where(tbl_solicitation_quotes => tbl_solicitation_quotes.Solicitation_Quotes_ID == key));
        }

        // PUT odata/SolicitationQuotes(5)
        public IHttpActionResult Put([FromODataUri] int key, tbl_Solicitation_Quotes tbl_solicitation_quotes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != tbl_solicitation_quotes.Solicitation_Quotes_ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_solicitation_quotes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Solicitation_QuotesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_solicitation_quotes);
        }

        // POST odata/SolicitationQuotes
        public IHttpActionResult Post(tbl_Solicitation_Quotes tbl_solicitation_quotes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Solicitation_Quotes.Add(tbl_solicitation_quotes);
            db.SaveChanges();

            return Created(tbl_solicitation_quotes);
        }

        // PATCH odata/SolicitationQuotes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<tbl_Solicitation_Quotes> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_Solicitation_Quotes tbl_solicitation_quotes = db.tbl_Solicitation_Quotes.Find(key);
            if (tbl_solicitation_quotes == null)
            {
                return NotFound();
            }

            patch.Patch(tbl_solicitation_quotes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Solicitation_QuotesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_solicitation_quotes);
        }

        // DELETE odata/SolicitationQuotes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            tbl_Solicitation_Quotes tbl_solicitation_quotes = db.tbl_Solicitation_Quotes.Find(key);
            if (tbl_solicitation_quotes == null)
            {
                return NotFound();
            }

            db.tbl_Solicitation_Quotes.Remove(tbl_solicitation_quotes);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/SolicitationQuotes(5)/tbl_Quote_Quantities
        [EnableQuery]
        public IQueryable<tbl_Quote_Quantities> Gettbl_Quote_Quantities([FromODataUri] int key)
        {
            return db.tbl_Solicitation_Quotes.Where(m => m.Solicitation_Quotes_ID == key).SelectMany(m => m.tbl_Quote_Quantities);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Solicitation_QuotesExists(int key)
        {
            return db.tbl_Solicitation_Quotes.Count(e => e.Solicitation_Quotes_ID == key) > 0;
        }
    }
}
