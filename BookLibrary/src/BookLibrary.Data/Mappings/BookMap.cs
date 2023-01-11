using BookLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data.Mappings
{
    public class BookMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(v =>
            {
                v.HasKey(x => x.BookId);

                v.Property(d => d.Category);
                v.Property(d => d.ISBN);
                v.Property(d => d.FirstName);
                v.Property(d => d.TotalCopies);
                v.Property(d => d.CopiesInUse);
                v.Property(d => d.LastName);
                v.Property(d => d.Title);
                v.Property(d => d.Type);
            });
        }
    }
}
