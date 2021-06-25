using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteAPI.Repository;
using QuoteAPI.Domain;

namespace QuoteAPI.Services
{
    public class Service
    {
        public static readonly QuoteDatabaseEntities context = new QuoteDatabaseEntities();
        UnitOfWork unw = new UnitOfWork(context);

        public Service()
        {

        }

        public IEnumerable<Quote> GetAllQuotes()
        {
            IEnumerable<Quote> quotes = unw.quote.GetAll();

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

        public Quote getQuote(int id)
        {
            Quote quote = unw.quote.GetByID(id);
            quote.QuoteType = quote.QuoteType.Trim();
            quote.Contact = quote.Contact.Trim();
            quote.Task = quote.Task.Trim();
            quote.QuoteType = quote.QuoteType.Trim();
            quote.TaskType = quote.TaskType.Trim();

            return quote;
        }

        public void insertQuote(Quote quote)
        {
            unw.quote.Insert(quote);
            unw.SaveChanges();
        }

        public bool removeQuote(int quoteID)
        {
            Quote QuoteToDelete = unw.quote.GetByID(quoteID);
            if (QuoteToDelete != null)
            {
                unw.quote.Delete(QuoteToDelete);
                unw.SaveChanges();
                return true;
            }
            return false;
        }

        public bool updateQuote(int id, Quote quote)
        {
            Quote QuoteToUpdate = unw.quote.GetByID(id);

            if(QuoteToUpdate != null)
            {
                QuoteToUpdate.QuoteType = quote.QuoteType;
                QuoteToUpdate.Contact = quote.Contact;
                QuoteToUpdate.Task = quote.Task;
                QuoteToUpdate.QuoteType = quote.QuoteType;
                QuoteToUpdate.TaskType = quote.TaskType;

                unw.quote.Update(QuoteToUpdate);
                unw.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
