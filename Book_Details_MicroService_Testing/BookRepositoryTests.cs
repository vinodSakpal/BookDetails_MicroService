using System;
using System.Collections.Generic;
using BookDetails_MicroService.Repository;
using BookDetails_MicroService.Model;
using BookDetails_MicroService.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace Book_Details_MicroService_Testing
{
    public class BookRepositoryTests : IBookRepository
    {
        private readonly List<BookMaster> _bookCart;
        BookDBContext context;

        public BookRepositoryTests(BookDBContext _Contexts)
        {
            _bookCart = new List<BookMaster>()
            {
                new BookMaster() { Id = 1,
                    Book_Name = "Dot Net", Book_Author_Name="XYZ", ISBN_Num = "12345",Book_Publication_Date=DateTime.Parse("10/10/2020") },
                new BookMaster() { Id = 1,
                    Book_Name = "Dot Net1", Book_Author_Name="ABC", ISBN_Num = "123451",Book_Publication_Date=DateTime.Parse("10/10/2020") },
                new BookMaster() { Id = 1,
                    Book_Name = "Dot Net2", Book_Author_Name="XYZ", ISBN_Num = "123452",Book_Publication_Date=DateTime.Parse("10/10/2020") }
            };
            context = _Contexts;
            
        }

        public IEnumerable<BookMaster> GetBookMaster()
        {
            return _bookCart;
        }
        public void InsertBook(BookMaster newItem)
        {
            newItem.Id = 0;
            _bookCart.Add(newItem);
            //return newItem;
        }
        public BookMaster GetBook_byCode(decimal id)
        {
            return _bookCart.Find(a => a.Id == id);
                      }
        public void DeleteBook(decimal id)
        {
            var existing = _bookCart.Find(a => a.Id == id);
            _bookCart.Remove(existing);
        }

        public void UpdateBook(BookMaster newItem)
        {
            context.Entry(newItem).State = EntityState.Modified;
            context.SaveChanges();
        }



    }
}
