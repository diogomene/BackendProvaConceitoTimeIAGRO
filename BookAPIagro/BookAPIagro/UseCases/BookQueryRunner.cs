using BookAPIagro.Controllers.Utilities;
using BookAPIagro.DataStore;
using BookAPIagro.Entities;

namespace BookAPIagro.UseCases
{
    public class BookQueryRunner
    {
        public static IEnumerable<Book> RunQuery(BookQuery query)
        {
            BookStore bookStore = new BookStore();
            IEnumerable<Book> result = bookStore.StoreList;
            if(query.Title != null)
            {
                result = bookStore.GetByTitle(query.Title.ToLower());
            }
            if(query.Author != null)
            {
                result = result.GetByAuthor(query.Author.ToLower());
            }
        }
    }
}
