using BookLibrary.Data.Contexts;
using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Domain.Models;

namespace BookLibrary.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(SqlContext sqlContext) : base(sqlContext)
        {

        }
    }
}
