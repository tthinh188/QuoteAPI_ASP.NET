using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using QuoteAPI.Domain;
using QuoteAPI.Services;

namespace QuoteAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Quote")]
    public class QuoteController: ApiController
    {
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            Service service = new Service();
            IEnumerable<Quote> quotes = service.GetAllQuotes();

            foreach (var quote in quotes)
            {
                quote.QuoteType = quote.QuoteType.Trim();
                quote.Contact = quote.Contact.Trim();
                quote.Task = quote.Task.Trim();
                quote.QuoteType = quote.QuoteType.Trim();
                quote.TaskType = quote.TaskType.Trim();
            }
            return quotes;
        }

        [HttpGet]
        public Quote Get(int id)
        {
            Service service = new Service();
            return service.getQuote(id);
        }

        [HttpPost]
        [Route("AddQuote")]
        public IHttpActionResult AddQuote(Quote quote)
        {
            Service service = new Service();
            service.insertQuote(quote);
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            Service service = new Service();
            bool updated = service.updateQuote(id, quote);
            if(updated)
                return Ok();
            else
                return NotFound();

        }

        public IHttpActionResult Delete(int id)
        {
            Service service = new Service();
            bool removed = service.removeQuote(id);
            if (removed)
                return Ok();
            else
                return NotFound();
        }
    }
}