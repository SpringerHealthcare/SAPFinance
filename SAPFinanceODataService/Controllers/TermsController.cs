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
    public class TermsController : ODataController
    {
        private QuotesContext db = new QuotesContext();

        // GET odata/Terms
        [EnableQuery]
        public IQueryable<vw_SAPFinance_Terms> GetTerms()
        {
            return db.tbl_term;
        }

        // GET odata/Terms(5)
        [EnableQuery]
        public SingleResult<vw_SAPFinance_Terms> Gettbl_term([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_term.Where(tbl_term => tbl_term.term_id == key));
        }

        // PUT odata/Terms(5)
        public IHttpActionResult Put([FromODataUri] int key, vw_SAPFinance_Terms tbl_term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != tbl_term.term_id)
            {
                return BadRequest();
            }

            db.Entry(tbl_term).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_termExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_term);
        }

        // POST odata/Terms
        public IHttpActionResult Post(vw_SAPFinance_Terms tbl_term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_term.Add(tbl_term);
            db.SaveChanges();

            return Created(tbl_term);
        }

        // PATCH odata/Terms(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<vw_SAPFinance_Terms> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vw_SAPFinance_Terms tbl_term = db.tbl_term.Find(key);
            if (tbl_term == null)
            {
                return NotFound();
            }

            patch.Patch(tbl_term);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_termExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_term);
        }

        // DELETE odata/Terms(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            vw_SAPFinance_Terms tbl_term = db.tbl_term.Find(key);
            if (tbl_term == null)
            {
                return NotFound();
            }

            db.tbl_term.Remove(tbl_term);
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

        private bool tbl_termExists(int key)
        {
            return db.tbl_term.Count(e => e.term_id == key) > 0;
        }
    }
}
