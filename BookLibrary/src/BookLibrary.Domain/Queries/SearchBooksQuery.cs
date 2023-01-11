using BookLibrary.Domain.Dto;

namespace BookLibrary.Domain.Queries
{
    public class SearchBooksQuery : Query<List<BookDto>>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
