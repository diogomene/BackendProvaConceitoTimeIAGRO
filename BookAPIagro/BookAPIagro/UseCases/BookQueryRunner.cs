using BookAPIagro.Controllers.Utilities;
using BookAPIagro.DataStore;
using BookAPIagro.Entities;

namespace BookAPIagro.UseCases
{
    public class BookQueryRunner
    {
        public static IEnumerable<Book> RunQuery(BookQuery query)
        {
            BookStoreList result = BookStore.GetInstance().StoreList;
            if(query.Title != default)
            {
                result = result.GetByTitle(query.Title.ToLower());
            }
            if(query.MinPrice != default || query.MaxPrice != default)
            {
                result = result.GetByPriceRange(new Range<decimal>(query.MinPrice, query.MaxPrice));
            }
            if(query.StartPublishDate != default || query.EndPublishDate != default)
            {
                DateOnly start = DateOnly.FromDateTime(query.StartPublishDate ?? DateTime.MinValue);
                DateOnly end = DateOnly.FromDateTime(query.EndPublishDate ?? DateTime.MaxValue);
                result = result.GetByPublishDateRange(new Range<DateOnly>(start, end));
            }
            if(query.MinPageCount != default || query.MaxPageCount != default)
            {
                result = result.GetByPageCountRange(new Range<uint>(query.MinPageCount, query.MaxPageCount));
            }
            if(query.Author != default && query.Author.Count > 0)
            {
                result = result.GetByAuthors(query.Author);
            }
            if(query.Illustrator != default && query.Illustrator.Count > 0)
            {
                result = result.GetByIllustrators(query.Illustrator);
            }
            if(query.Genre != default && query.Genre.Count > 0)
            {
                result = result.GetByGenres(query.Genre);
            }
            return result.BookList;
        }
    }
}
