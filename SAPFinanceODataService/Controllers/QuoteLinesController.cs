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
    public class QuoteLinesController : ODataController
    {
        private QuotesContext db = new QuotesContext();

        // GET odata/QuoteLines
        [EnableQuery]
        public IQueryable<vw_SAPFinance_QuoteLines> GetQuoteLines()
        {
            return db.vw_SAPFinance_QuoteLines;
        }

        // GET odata/QuoteLines(5)
        [EnableQuery]
        public SingleResult<vw_SAPFinance_QuoteLines> Getvw_SAPFinance_QuoteLines([FromODataUri] int key)
        {
            return SingleResult.Create(db.vw_SAPFinance_QuoteLines.Where(vw_sapfinance_quotelines => vw_sapfinance_quotelines.Quantity_ID == key));
        }

        // PUT odata/QuoteLines(5)
        public IHttpActionResult Put([FromODataUri] int key, vw_SAPFinance_QuoteLines vw_sapfinance_quotelines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != vw_sapfinance_quotelines.Quantity_ID)
            {
                return BadRequest();
            }

            db.Entry(vw_sapfinance_quotelines).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vw_SAPFinance_QuoteLinesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(vw_sapfinance_quotelines);
        }

        // POST odata/QuoteLines
        public IHttpActionResult Post(vw_SAPFinance_QuoteLines vw_sapfinance_quotelines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vw_SAPFinance_QuoteLines.Add(vw_sapfinance_quotelines);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vw_SAPFinance_QuoteLinesExists(vw_sapfinance_quotelines.Quantity_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(vw_sapfinance_quotelines);
        }

        // PATCH odata/QuoteLines(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<vw_SAPFinance_QuoteLines> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vw_SAPFinance_QuoteLines vw_sapfinance_quotelines = db.vw_SAPFinance_QuoteLines.Find(key);
            if (vw_sapfinance_quotelines == null)
            {
                return NotFound();
            }

            patch.Patch(vw_sapfinance_quotelines);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vw_SAPFinance_QuoteLinesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(vw_sapfinance_quotelines);
        }

        // DELETE odata/QuoteLines(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            vw_SAPFinance_QuoteLines vw_sapfinance_quotelines = db.vw_SAPFinance_QuoteLines.Find(key);
            if (vw_sapfinance_quotelines == null)
            {
                return NotFound();
            }

            db.vw_SAPFinance_QuoteLines.Remove(vw_sapfinance_quotelines);
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

        private bool vw_SAPFinance_QuoteLinesExists(int key)
        {
            return db.vw_SAPFinance_QuoteLines.Count(e => e.Quantity_ID == key) > 0;
        }
    }
}
