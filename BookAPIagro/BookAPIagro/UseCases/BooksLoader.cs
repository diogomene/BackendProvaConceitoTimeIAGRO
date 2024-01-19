using BookAPIagro.Entities;

namespace BookAPIagro.UseCases
{
    public class BooksLoader
    {

        public static IEnumerable<Book> LoadBooks(string jsonPath)
        {
            BookDTO[]? books = DataAccess.JSONParser<BookDTO[]>.ParseJson(jsonPath);
            if(books == null)
            {
                return [];
            }
            return books.Select(b => b.ToBook());
        }

    }

}
