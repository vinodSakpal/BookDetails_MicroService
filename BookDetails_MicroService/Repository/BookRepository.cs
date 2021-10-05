using System;
using System.Collections.Generic;
using BookDetails_MicroService.DBContexts;
using BookDetails_MicroService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookDetails_MicroService.Repository
{
    public class BookRepository : IBookRepository
    {
        BookDBContext context;
        private ILogger<BookRepository> logger;
        private IBookRepository service;

        public BookRepository(BookDBContext _Contexts)
        {
            context = _Contexts;
        }

        
        public void DeleteBook(Decimal ID)
        {
            var book = context.BookMasters.Find(ID);
            context.BookMasters.Remove(book);
            context.SaveChanges();
        }

        public IEnumerable<BookMaster> GetBookMaster()
        {
            return context.BookMasters;
        }

        public BookMaster GetBook_byCode(Decimal Code)
        {
            return context.BookMasters.Find(Code);
        }

        public void InsertBook(BookMaster loc)
        {
            context.Add(loc);
            context.SaveChanges();
        }

        public void UpdateBook(BookMaster loc)
        {
            context.Entry(loc).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
