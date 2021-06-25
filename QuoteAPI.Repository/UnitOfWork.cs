using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using QuoteAPI.Repository.Repositories;

namespace QuoteAPI.Repository
{
    public class UnitOfWork : IDisposable
    {
        DbContext Context;
        public IQuoteRepo quote;

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
            quote = new QuoteRepo(Context);
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
