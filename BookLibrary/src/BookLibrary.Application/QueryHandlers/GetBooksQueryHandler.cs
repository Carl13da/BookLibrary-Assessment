using BookLibrary.Domain.Dto;
using BookLibrary.Domain.Events;
using BookLibrary.Domain.Interfaces.Services;
using BookLibrary.Domain.Queries;

namespace BookLibrary.Application.QueryHandlers
{
    public class GetBooksQueryHandler : MediatorQueryHandler<SearchBooksQuery, List<BookDto>>
    {
        private readonly IBookService _bookService;

        public GetBooksQueryHandler(IMediatorHandler mediator, IBookService bookService) : base(mediator)
        {
            _bookService = bookService;
        }

        public override async Task<List<BookDto>> AfterValidation(SearchBooksQuery request)
        {
            var (hasError, books, error) = await _bookService.GetBooks();

            if (hasError)
            {
                NotifyError(error);

                return null;
            }

            return books;
        }
    }
}
