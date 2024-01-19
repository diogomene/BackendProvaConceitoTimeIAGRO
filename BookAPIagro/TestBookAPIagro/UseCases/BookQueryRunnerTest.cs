using BookAPIagro.Controllers.Utilities;
using BookAPIagro.DataStore;
using BookAPIagro.UseCases;
using BookAPIagro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBookAPIagro.TestMock;

namespace TestBookAPIagro.UseCases
{
    [TestClass]
    public class BookQueryRunnerTest
    {
        [TestInitialize]
        public void Initialize()
        {
            BookStoreFaker.CreateBookStore();
        }

        [TestMethod]
        public void GetAllBooksTest() 
        {
            var result = BookQueryRunner.RunQuery(new BookQuery());

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            Assert.AreEqual("Journey to the Center of the Earth", result.First().Title);
            Assert.AreEqual("The Lord of the Rings", result.Last().Title);
        }

        [TestMethod]
        public void GetByExactTitleTest() { 
            var query = new BookQuery();
            query.Title = "Journey to the Center of the Earth";
            var result = BookQueryRunner.RunQuery(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Journey to the Center of the Earth", result.First().Title);
            Assert.AreEqual("Jules Verne", result.First().Author.First().Name);   
        }
        [TestMethod]
        public void GetByInitialTitlePartTest()
        {
            var query = new BookQuery();
            query.Title = "Journey to the";
            var result = BookQueryRunner.RunQuery(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Journey to the Center of the Earth", result.First().Title);
            Assert.AreEqual("Jules Verne", result.First().Author.First().Name);
        }
        [TestMethod]
        public void GetByEndTitlePartTest()
        {
            var query = new BookQuery();
            query.Title = "Journey to the";
            var result = BookQueryRunner.RunQuery(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Journey to the Center of the Earth", result.First().Title);
            Assert.AreEqual("Jules Verne", result.First().Author.First().Name);
        }
        [TestMethod]
        public void GetByVeryGenericTitleTest()
        {
            var query = new BookQuery();
            query.Title = "A";
            var result = BookQueryRunner.RunQuery(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.AreEqual("Journey to the Center of the Earth", result.First().Title);
            Assert.AreEqual("Jules Verne", result.First().Author.First().Name);


        }

        [TestMethod]
        public void GetByPriceRangeWithUnboundedMaxTest()
        {
            var query = new BookQuery();

            query.MinPrice = 10.10m;
            var result = BookQueryRunner.RunQuery(query);

            query.MinPrice = 10.0m;
            var result2 = BookQueryRunner.RunQuery(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(b => b.Title == "20,000 Leagues Under the Sea"));
            Assert.IsTrue(result.Any(b => b.Title == "Fantastic Beasts and Where to Find Them: The Original Screenplay"));

            Assert.IsNotNull(result2);
            Assert.AreEqual(3, result2.Count());
            Assert.IsTrue(result2.Any(b => b.Title == "20,000 Leagues Under the Sea"));
            Assert.IsTrue(result2.Any(b => b.Title == "Fantastic Beasts and Where to Find Them: The Original Screenplay"));
            Assert.IsTrue(result2.Any(b => b.Title == "Journey to the Center of the Earth"));
        }

        [TestMethod]
        public void GetByPriceRangeWithUnboundedMinTest()
        {
            var query = new BookQuery();

            query.MaxPrice = 10.10m;
            var result = BookQueryRunner.RunQuery(query);

            query.MaxPrice = 6.15m;
            var result2 = BookQueryRunner.RunQuery(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.IsTrue(result.Any(b => b.Title == "20,000 Leagues Under the Sea"));
            Assert.IsTrue(result.Any(b => b.Title == "Journey to the Center of the Earth"));
            Assert.IsTrue(result.Any(b => b.Title == "Harry Potter and the Goblet of Fire"));
            Assert.IsTrue(result.Any(b => b.Title == "The Lord of the Rings"));

            Assert.IsNotNull(result2);
            Assert.AreEqual(1, result2.Count());
            Assert.IsTrue(result2.Any(b => b.Title == "The Lord of the Rings"));
        }

        [TestMethod]
        public void GetByPriceRangeWithBoundedTest()
        {
            var query = new BookQuery();
            query.MinPrice = 6.15m;
            query.MaxPrice = 7.31m;
            var result = BookQueryRunner.RunQuery(query);

            query.MinPrice = 10.0m;
            query.MaxPrice = 10.00m;
            var result2 = BookQueryRunner.RunQuery(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(b => b.Title == "Harry Potter and the Goblet of Fire"));
            Assert.IsTrue(result.Any(b => b.Title == "The Lord of the Rings"));


            Assert.IsNotNull(result2);
            Assert.AreEqual(1, result2.Count());
            Assert.IsTrue(result2.Any(b => b.Title == "Journey to the Center of the Earth"));
        }   


    }
}
