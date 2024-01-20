using BookAPIagro.Controllers;
using BookAPIagro.Controllers.Utilities;
using BookAPIagro.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBookAPIagro.TestMock;

namespace TestBookAPIagro.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {
        [TestInitialize]
        public void Initialize()
        {
            BookStoreFaker.CreateBookStore();
        }

        [TestMethod]
        public void GetAllBooksTest()
        {
            BooksController controller = new BooksController();

            IActionResult result = controller.Get();

            Assert.IsNotNull(result);
            var okRes = result as OkObjectResult;
            Assert.IsNotNull(okRes);
            Assert.AreEqual(200, okRes.StatusCode);
            IEnumerable<BookDTO>? books = okRes.Value as IEnumerable<BookDTO>;
            Assert.IsNotNull(books);
            Assert.AreEqual(5, books.Count());
        }

        [TestMethod]
        public void GetBookDTOById() { 

            BooksController controller = new BooksController();

            IActionResult result = controller.Get(1);

            Assert.IsNotNull(result);
            var okRes = result as OkObjectResult;
            Assert.IsNotNull(okRes);
            Assert.AreEqual(200, okRes.StatusCode);
            BookDTO? book = okRes.Value as BookDTO;
            Assert.IsNotNull(book);
            Assert.AreEqual((uint)1, book.Id);
            Assert.AreEqual("Journey to the Center of the Earth", book.Name);
            Assert.AreEqual(10.00m, book.Price);
            Assert.AreEqual("25/11/1864", book.Specifications.Originally_published);
            Assert.AreEqual((uint)183, book.Specifications.Page_count);
            Assert.AreEqual("Jules Verne", book.Specifications.Author[0]);
            Assert.AreEqual(2.00m, book.Frete);
        }

        [TestMethod]
        public void GetBookDTOByIdNotFound()
        {
            BooksController controller = new BooksController();

            IActionResult result = controller.Get(uint.MaxValue);

            Assert.IsNotNull(result);
            var okRes = result as OkObjectResult;
            Assert.IsNotNull(okRes);
            Assert.AreEqual(200, okRes.StatusCode);
            BookDTO? book = okRes.Value as BookDTO;
            Assert.IsNull(book);
        }

        [TestMethod]
        public void QueryBookDTO() { 

            BooksController controller = new BooksController();

            BookQuery query = new BookQuery();
            query.Title = "20,000 Leagues Under the Sea";
            query.Author = ["Jules Verne"];

            IActionResult actionResult = controller.Query(query);

            Assert.IsNotNull(actionResult);
            var okRes = actionResult as OkObjectResult;
            Assert.IsNotNull(okRes);
            Assert.AreEqual(200, okRes.StatusCode);
            IEnumerable<BookDTO>? books = okRes.Value as IEnumerable<BookDTO>;
            Assert.IsNotNull(books);
            Assert.AreEqual(1, books.Count());
            BookDTO? book = books.First();
            Assert.AreEqual((uint)2, book.Id);
            Assert.AreEqual("20,000 Leagues Under the Sea", book.Name);
            Assert.AreEqual(10.10m, book.Price);
            Assert.AreEqual("20/06/1870", book.Specifications.Originally_published);
            Assert.AreEqual((uint)213, book.Specifications.Page_count);
            Assert.AreEqual("Jules Verne", book.Specifications.Author[0]);
            Assert.AreEqual("Édouard Riou", book.Specifications.Illustrator[0]);
            Assert.AreEqual("Adventure fiction", book.Specifications.Genres[0]);
            Assert.AreEqual(2.020m, book.Frete);
        }

        [TestMethod]
        public void QueryAllBookDTOByAscOrder() { 
            BooksController controller = new BooksController();
    
                BookQuery query = new BookQuery();
                query.orderPriceBy = OrderType.Asc;
    
                IActionResult actionResult = controller.Query(query);
    
                Assert.IsNotNull(actionResult);
                var okRes = actionResult as OkObjectResult;
                Assert.IsNotNull(okRes);
                Assert.AreEqual(200, okRes.StatusCode);
                IEnumerable<BookDTO>? books = okRes.Value as IEnumerable<BookDTO>;
                Assert.IsNotNull(books);
                Assert.AreEqual(5, books.Count());
                BookDTO? book = books.First();
                Assert.AreEqual("The Lord of the Rings", book.Name);
        }
        public void QueryAllBookDTOByDescOrder()
        {
            BooksController controller = new BooksController();

            BookQuery query = new BookQuery();
            query.orderPriceBy = OrderType.Desc;

            IActionResult actionResult = controller.Query(query);

            Assert.IsNotNull(actionResult);
            var okRes = actionResult as OkObjectResult;
            Assert.IsNotNull(okRes);
            Assert.AreEqual(200, okRes.StatusCode);
            IEnumerable<BookDTO>? books = okRes.Value as IEnumerable<BookDTO>;
            Assert.IsNotNull(books);
            Assert.AreEqual(5, books.Count());
            BookDTO? book = books.First();
            Assert.AreEqual("Fantastic Beasts and Where to Find Them: The Original Screenplay", book.Name);
        }

    }
}
