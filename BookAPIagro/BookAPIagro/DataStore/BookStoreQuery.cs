using BookAPIagro.Entities;

namespace BookAPIagro.DataStore {
    public static class BookStoreQuery
    {

        public static Book? GetById(this BookStore bookStore, uint id)
        {
            return bookStore.Store.Find(b => b.Id == id);
        }
        public static IEnumerable<Book> GetByTitle(this BookStore bookStore, string title)
        {
            return bookStore.Store.FindAll(b => b.Title.Contains(title));
        }
        public static IEnumerable<Book> GetByPriceRange(this BookStore bookStore, Range<decimal> priceRange)
        {
            return bookStore.Store.FindAll(b => priceRange.Contains(b.Price));
        }
        public static IEnumerable<Book> GetByPublishDateRange(this BookStore bookStore, Range<DateOnly> publishDateRange)
        {
            return bookStore.Store.FindAll(b => publishDateRange.Contains(b.PublishDate));
        }

        public static IEnumerable<Book> GetByAuthors(this BookStore bookStore, IEnumerable<string> authors)
        {
            return bookStore.Store.FindAll(b => b.Author.Any(a => authors.Contains(a.Name)));
        }

        public static IEnumerable<Book> GetByGenres(this BookStore bookStore, IEnumerable<string> genres)
        {
            return bookStore.Store.FindAll(b => b.Genre.Any(g => genres.Contains(g.Name)));
        }

        public static IEnumerable<Book> GetByIllustrators(this BookStore bookStore, IEnumerable<string> illustrators)
        {
            return bookStore.Store.FindAll(b => b.Illustrator.Any(i => illustrators.Contains(i.Name)));
        }
    }

    public class Range<T>(T? Min, T? Max) where T:IComparable
    {
        public T? Min { get; set; } = Min;
        public T? Max { get; set; } = Max;
        public bool Contains(T value)
        {
            if (Min != null && value.CompareTo(Min) < 0)
            {
                return false;
            }

            if (Max != null && value.CompareTo(Max) > 0)
            {
                return false;
            }

            return true;
        }
    }
}
