using System;
using System.Collections.Generic;
using BookDetails_MicroService.DBContexts;
using BookDetails_MicroService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Web;
using System.Linq;

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

        public void DeleteBook(int id)
        {
            var book = context.BookMasters.Find(id);
            context.BookMasters.Remove(book);
            context.SaveChanges();
        }

        public IEnumerable<BookMaster> GetBookMaster()
        {
            return context.BookMasters;
        }

        public BookMaster GetBook_byCode(int id)
        {
            return context.BookMasters.Find(id);
        }

        public IEnumerable<BookMaster> GetBook_byISBN(string ISBN)
        {
            var abc = context.BookMasters.Where(s => s.ISBN_Num.Contains(ISBN));
            return abc;
        }

        public void InsertBook(BookMaster loc)
        {
            context.BookMasters.Add(loc);
            context.SaveChanges();
        }

        public void UpdateBook(BookMaster loc)
        {
            context.Entry(loc).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
