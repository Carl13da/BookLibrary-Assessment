using BookLibrary.Domain.Dto;
using BookLibrary.Domain.Events;
using BookLibrary.Domain.Helpers;
using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace BookLibrary.Application.Services
{
    public class BookService : ServiceMediator, IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly string _accessKey;

        public BookService(IMediatorHandler mediator, IBookRepository bookRepository, IConfiguration configuration) : base(mediator)
        {
            _bookRepository = bookRepository;
            _accessKey = configuration["ConnectionStrings:AccessKey"];
        }

        public async Task<Tuple<bool, List<BookDto>, string>> GetBooks()
        {
            var books = await _bookRepository.GetAll();

            var resultDto = books.MergeToDestination<List<BookDto>>();

            return Tuple.Create(false, resultDto, string.Empty);
        }
    }
}
