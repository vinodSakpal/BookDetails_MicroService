
using BookDetails_MicroService.Model;
using Microsoft.EntityFrameworkCore;

namespace BookDetails_MicroService.DBContexts
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> dbContext) : base(dbContext) { }
        public DbSet<BookMaster> BookMasters { get; set; }
    }
}
