using System;
using System.Collections.Generic;
using BookDetails_MicroService.Repository;
using BookDetails_MicroService.Model;
using BookDetails_MicroService.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Book_Details_MicroService_Testing
{
    public class InMemoryBookRepository : IBookRepository
    {
        private List<BookMaster> _bookCart;

        public InMemoryBookRepository()
        {
            _bookCart = new List<BookMaster>()
            {
                new BookMaster() { Id = 1,
                    Book_Name = "Dot Net", Book_Author_Name="XYZ", ISBN_Num = "1234567890123",Book_Publication_Date=DateTime.Parse("10/10/2020") },
                new BookMaster() { Id = 1,
                    Book_Name = "Dot Net1", Book_Author_Name="ABC", ISBN_Num = "1234567890123",Book_Publication_Date=DateTime.Parse("10/10/2020") },
                new BookMaster() { Id = 1,
                    Book_Name = "Dot Net2", Book_Author_Name="XYZ", ISBN_Num = "1234567890123",Book_Publication_Date=DateTime.Parse("10/10/2020") }
            };
        }

        public IEnumerable<BookMaster> GetBookMaster()
        {
            return _bookCart;
        }

        public void InsertBook(BookMaster newItem)
        {
            newItem.Id = 0;
            _bookCart.Add(newItem);

        }

        public BookMaster GetBook_byCode(int id)
        {
            return _bookCart.Find(a => a.Id == id);
        }


        public void DeleteBook(int id)
        {
            var existing = _bookCart.Find(a => a.Id == id);
            _bookCart.Remove(existing);
        }

        public void UpdateBook(BookMaster newItem)
        {
        }

        public IEnumerable<BookMaster>GetBook_byISBN(string isbn)
        {
            return _bookCart.Where(s => s.ISBN_Num.Contains(isbn));
        } 

    }
}
