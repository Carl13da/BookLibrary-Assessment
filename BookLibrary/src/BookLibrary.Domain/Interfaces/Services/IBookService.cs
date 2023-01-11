using BookLibrary.Domain.Dto;

namespace BookLibrary.Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<Tuple<bool, List<BookDto>, string>> GetBooks();
    }
}
