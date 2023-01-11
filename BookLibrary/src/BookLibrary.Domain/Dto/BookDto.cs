namespace BookLibrary.Domain.Dto
{
    // I will replicate the Book model to gain some time
    public class BookDto
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string? Type { get; set; }
        public string? ISBN { get; set; }
        public string? Category { get; set; }
    }
}
