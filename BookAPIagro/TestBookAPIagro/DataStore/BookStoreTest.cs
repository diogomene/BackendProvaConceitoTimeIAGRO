using BookAPIagro.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBookAPIagro.DataStore
{
    [TestClass]
    public class BookStoreTest
    {
        [TestMethod]
        public void GetSingletownInstanceFromBookStore()
        {
            BookStore store = BookStore.GetInstance();
            Assert.IsNotNull(store);
            Assert.IsTrue(store is BookStore);

            BookStore store2 = BookStore.GetInstance();
            Assert.IsNotNull(store2);
            Assert.IsTrue(store2 is BookStore);
            Assert.AreEqual(store, store2);
        }
    }
}
