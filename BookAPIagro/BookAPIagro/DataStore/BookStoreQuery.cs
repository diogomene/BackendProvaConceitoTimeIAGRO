using BookAPIagro.Controllers.Utilities;
using BookAPIagro.Entities;

namespace BookAPIagro.DataStore {
    public static class BookStoreQuery
    {

        public static Book? GetById(this BookStoreList bookStore, uint id)
        {
            return bookStore.BookList.Find(b => b.Id == id);
        }
        public static BookStoreList GetByTitle(this BookStoreList bookStore, string title)
        {
            return new BookStoreList(
                bookStore.BookList.FindAll(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                );
        }
        public static BookStoreList GetByPriceRange(this BookStoreList bookStore, Range<decimal> priceRange)
        {
            return new BookStoreList(
                bookStore.BookList.FindAll(b => priceRange.Contains(b.Price))
                );
        }
        public static BookStoreList GetByPublishDateRange(this BookStoreList bookStore, Range<DateOnly> publishDateRange)
        {
            return new BookStoreList(
                bookStore.BookList.FindAll(b => publishDateRange.Contains(b.PublishDate))
                );
        }
        public static BookStoreList GetByPageCountRange(this BookStoreList bookStore, Range<uint> pageCountRange)
        {
            return new BookStoreList(
                bookStore.BookList.FindAll(b => pageCountRange.Contains(b.PageCount))
                );
        }
        public static BookStoreList GetByAuthors(this BookStoreList bookStore, IEnumerable<string> authors)
        {
            return new BookStoreList(
                bookStore.BookList.FindAll(b => b.Author.Any(bookAuthor => authors.Any(searchedAuthor=> bookAuthor.Name.Contains(searchedAuthor, StringComparison.OrdinalIgnoreCase) )))
                );
        }

        public static BookStoreList GetByGenres(this BookStoreList bookStore, IEnumerable<string> genres)
        {
            return new BookStoreList(
                bookStore.BookList.FindAll(b => b.Genre.Any(bookGenre => genres.Any(searchedGenre => bookGenre.Name.Contains(searchedGenre, StringComparison.OrdinalIgnoreCase) )))
                );
        }

        public static BookStoreList GetByIllustrators(this BookStoreList bookStore, IEnumerable<string> illustrators)
        {
            return new BookStoreList(
                bookStore.BookList.FindAll(b => b.Illustrator.Any(bookIllustrator => illustrators.Any(searchedIllustrator=> bookIllustrator.Name.Contains(searchedIllustrator, StringComparison.OrdinalIgnoreCase) )))
                );
        }

        public static BookStoreList OrderByPrice(this BookStoreList bookStore, OrderType orderType)
        {
            IEnumerable<Book> res = (bookStore.BookList.OrderBy(b => b.Price * (orderType == OrderType.Desc ? -1 : 1)));
            return new BookStoreList(res.ToList());
        }
    }

    public class Range<T>(T? Min, T? Max) where T : struct, IComparable<T>
    {

        public T? Min { get; set; } = Min;
        public T? Max { get; set; } = Max;

        public bool Contains(T value)
        {
            if (Min.HasValue && value.CompareTo((T)Min) < 0)
            {
                return false;
            }

            if (Max.HasValue && value.CompareTo((T)Max) > 0)
            {
                return false;
            }

            return true;
        }
    }
}
