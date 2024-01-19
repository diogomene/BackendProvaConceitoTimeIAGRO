using BookAPIagro.Entities;

namespace BookAPIagro.DataStore
{
    public class BookStore
    {
        public List<Book> Store = [];
        private static BookStore? Singleton;
        private static readonly object threadLock = new();

        public static BookStore GetInstance()
        {
            if (Singleton == null)
            {
                lock (threadLock)
                {
                    if (Singleton == null)
                    {
                        Singleton = new BookStore();
                    }
                }
            }
            return Singleton;
        }
    }
}
