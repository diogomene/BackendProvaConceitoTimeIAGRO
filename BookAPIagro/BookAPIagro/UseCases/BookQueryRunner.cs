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

            if(query.Title != null)
            {
                result = result.GetByTitle(query.Title.ToLower());
            }
            if(query.MinPrice != null || query.MaxPrice != null)
            {
                result = result.GetByPriceRange(new Range<decimal>(query.MinPrice, query.MaxPrice));
            }
            if(query.StartPublishDate != null || query.EndPublishDate != null)
            {
                DateOnly start = DateOnly.FromDateTime(query.StartPublishDate ?? DateTime.MinValue);
                DateOnly end = DateOnly.FromDateTime(query.EndPublishDate ?? DateTime.MaxValue);
                result = result.GetByPublishDateRange(new Range<DateOnly>(start, end));
            }
            if(query.MinPageCount != null || query.MaxPageCount != null)
            {
                result = result.GetByPageCountRange(new Range<uint>(query.MinPageCount, query.MaxPageCount));
            }
            if(query.Author != null && query.Author.Count > 0)
            {
                result = result.GetByAuthors(query.Author);
            }
            if(query.Illustrator != null && query.Illustrator.Count > 0)
            {
                result = result.GetByIllustrators(query.Illustrator);
            }
            if(query.Genre != null && query.Genre.Count > 0)
            {
                result = result.GetByGenres(query.Genre);
            }
            return result;
        }
    }
}
