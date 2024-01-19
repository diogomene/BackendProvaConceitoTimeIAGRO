using BookAPIagro.DataStore;

namespace BookAPIagro.UseCases
{
    public class DataBootstrapper
    {
        private static string? getDataStoragePath() {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfigurationRoot confRoot = configurationBuilder.AddJsonFile("appsettings.json").Build();
            return confRoot.GetValue<string>("DataStorageFilePath");

        }

        public static void Bootstrap()
        {
            string? jsonPath = getDataStoragePath();
            BookStore bookStore = BookStore.GetInstance();
            if (jsonPath == null) return;
            bookStore.StoreList = new BookStoreList(BooksLoader.LoadBooks(jsonPath).ToList());
        }
    }
}
