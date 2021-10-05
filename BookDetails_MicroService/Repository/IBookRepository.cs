using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookDetails_MicroService.Model;

namespace BookDetails_MicroService.Repository
{
    public interface IBookRepository
    {
        IEnumerable<BookMaster> GetBookMaster();

        BookMaster GetBook_byCode(int id);

        void InsertBook(BookMaster loc);

        void UpdateBook(BookMaster loc);

        void DeleteBook(int id);
    }
}
