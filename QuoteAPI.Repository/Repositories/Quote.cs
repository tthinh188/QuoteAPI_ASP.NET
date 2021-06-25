using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteAPI.Domain;
using System.Data.Entity;

namespace QuoteAPI.Repository.Repositories
{
    public interface IQuoteRepo : IRepository<Quote>
    {
    }

    public class QuoteRepo : Repository<Quote>, IQuoteRepo
    {
        public QuoteRepo(DbContext context) : base(context)
        {
        }
    }
}
