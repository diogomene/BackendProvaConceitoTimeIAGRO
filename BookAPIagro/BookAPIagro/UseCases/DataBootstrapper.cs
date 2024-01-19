using BookAPIagro.DataStore;

namespace BookAPIagro.UseCases
{
    public class DataBootstrapper
    {
        public static void Bootstrap()
        {
            string jsonPath = "DataAccess/books.json";
            BookStore bookStore = BookStore.GetInstance();
            bookStore.StoreList = (BookStoreList)BooksLoader.LoadBooks(jsonPath).ToList();
        }
    }
}
