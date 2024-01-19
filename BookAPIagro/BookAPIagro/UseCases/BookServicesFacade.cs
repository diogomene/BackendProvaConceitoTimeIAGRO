using BookAPIagro.Controllers.Utilities;
using BookAPIagro.DataStore;
using BookAPIagro.Entities;

namespace BookAPIagro.UseCases
{
    public static class BookServicesFacade
    {
        public static IEnumerable<BookDTO> getAllBooks()
        {
            return BookStore.GetInstance().StoreList.BookList.ToArray().Select(book => new BookDTO(book));
        }
        public static BookDTO? getBookById(uint id)
        {
            Book? book = BookStore.GetInstance().StoreList.GetById(id);
            if(book != default)
            {
                return new BookDTO(book);
            }
            return default;
        }

        public static IEnumerable<BookDTO> queryBookList(BookQuery bookQuery)
        {
            return BookQueryRunner.RunQuery(bookQuery).Select(book => new BookDTO(book));
        }
    }
}
