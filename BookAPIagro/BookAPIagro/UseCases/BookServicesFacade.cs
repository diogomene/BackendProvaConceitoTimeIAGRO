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
        public static Book? getBookById(uint id)
        {
            return BookStore.GetInstance().StoreList.GetById(id);
        }

        public static IEnumerable<BookDTO> queryBookList(BookQuery bookQuery)
        {
            return BookQueryRunner.RunQuery(bookQuery).Select(book => new BookDTO(book));
        }
    }
}
