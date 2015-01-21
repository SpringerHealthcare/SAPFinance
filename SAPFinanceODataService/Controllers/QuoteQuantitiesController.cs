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
    public class QuoteQuantitiesController : ODataController
    {
        private QuotesContext db = new QuotesContext();

        // GET odata/QuoteQuantities
        [EnableQuery]
        public IQueryable<tbl_Quote_Quantities> GetQuoteQuantities()
        {
            return db.tbl_Quote_Quantities;
        }

        // GET odata/QuoteQuantities(5)
        [EnableQuery]
        public SingleResult<tbl_Quote_Quantities> Gettbl_Quote_Quantities([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_Quote_Quantities.Where(tbl_quote_quantities => tbl_quote_quantities.Quantity_ID == key));
        }

        // PUT odata/QuoteQuantities(5)
        public IHttpActionResult Put([FromODataUri] int key, tbl_Quote_Quantities tbl_quote_quantities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != tbl_quote_quantities.Quantity_ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_quote_quantities).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Quote_QuantitiesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_quote_quantities);
        }

        // POST odata/QuoteQuantities
        public IHttpActionResult Post(tbl_Quote_Quantities tbl_quote_quantities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Quote_Quantities.Add(tbl_quote_quantities);
            db.SaveChanges();

            return Created(tbl_quote_quantities);
        }

        // PATCH odata/QuoteQuantities(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<tbl_Quote_Quantities> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_Quote_Quantities tbl_quote_quantities = db.tbl_Quote_Quantities.Find(key);
            if (tbl_quote_quantities == null)
            {
                return NotFound();
            }

            patch.Patch(tbl_quote_quantities);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Quote_QuantitiesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_quote_quantities);
        }

        // DELETE odata/QuoteQuantities(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            tbl_Quote_Quantities tbl_quote_quantities = db.tbl_Quote_Quantities.Find(key);
            if (tbl_quote_quantities == null)
            {
                return NotFound();
            }

            db.tbl_Quote_Quantities.Remove(tbl_quote_quantities);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/QuoteQuantities(5)/tbl_Solicitation_Quotes
        [EnableQuery]
        public SingleResult<tbl_Solicitation_Quotes> Gettbl_Solicitation_Quotes([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_Quote_Quantities.Where(m => m.Quantity_ID == key).Select(m => m.tbl_Solicitation_Quotes));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Quote_QuantitiesExists(int key)
        {
            return db.tbl_Quote_Quantities.Count(e => e.Quantity_ID == key) > 0;
        }
    }
}
