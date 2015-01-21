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
    public class QuotesController : ODataController
    {
        private QuotesContext db = new QuotesContext();

        // GET odata/Quotes
        [EnableQuery]
        public IQueryable<vw_SAPFinance_Quotes> GetQuotes()
        {
            return db.vw_SAPFinance_Quotes;
        }

        // GET odata/Quotes(5)
        [EnableQuery]
        public SingleResult<vw_SAPFinance_Quotes> Getvw_SAPFinance_Quotes([FromODataUri] int key)
        {
            return SingleResult.Create(db.vw_SAPFinance_Quotes.Where(vw_sapfinance_quotes => vw_sapfinance_quotes.Solicitation_Quotes_ID == key));
        }

        // PUT odata/Quotes(5)
        public IHttpActionResult Put([FromODataUri] int key, vw_SAPFinance_Quotes vw_sapfinance_quotes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != vw_sapfinance_quotes.Solicitation_Quotes_ID)
            {
                return BadRequest();
            }

            db.Entry(vw_sapfinance_quotes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vw_SAPFinance_QuotesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(vw_sapfinance_quotes);
        }

        // POST odata/Quotes
        public IHttpActionResult Post(vw_SAPFinance_Quotes vw_sapfinance_quotes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vw_SAPFinance_Quotes.Add(vw_sapfinance_quotes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vw_SAPFinance_QuotesExists(vw_sapfinance_quotes.Solicitation_Quotes_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(vw_sapfinance_quotes);
        }

        // PATCH odata/Quotes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<vw_SAPFinance_Quotes> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vw_SAPFinance_Quotes vw_sapfinance_quotes = db.vw_SAPFinance_Quotes.Find(key);
            if (vw_sapfinance_quotes == null)
            {
                return NotFound();
            }

            patch.Patch(vw_sapfinance_quotes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vw_SAPFinance_QuotesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(vw_sapfinance_quotes);
        }

        // DELETE odata/Quotes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            vw_SAPFinance_Quotes vw_sapfinance_quotes = db.vw_SAPFinance_Quotes.Find(key);
            if (vw_sapfinance_quotes == null)
            {
                return NotFound();
            }

            db.vw_SAPFinance_Quotes.Remove(vw_sapfinance_quotes);
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

        private bool vw_SAPFinance_QuotesExists(int key)
        {
            return db.vw_SAPFinance_Quotes.Count(e => e.Solicitation_Quotes_ID == key) > 0;
        }
    }
}
