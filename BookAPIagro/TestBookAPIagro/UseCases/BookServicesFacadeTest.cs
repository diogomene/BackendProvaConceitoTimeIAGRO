using BookAPIagro.Controllers.Utilities;
using BookAPIagro.Entities;
using BookAPIagro.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBookAPIagro.TestMock;

namespace TestBookAPIagro.UseCases
{
    [TestClass]
    public class BookServicesFacadeTest
    {
        [TestInitialize]
        public void init()
        {
            BookStoreFaker.CreateBookStore();
        }

        [TestMethod]
        public void GetAllBooksDTO()
        {
            IEnumerable<BookDTO> result = BookServicesFacade.getAllBooks();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 5);
        }


        [TestMethod]
        public void GetBookDTOByID()
        {
            BookDTO? result = BookServicesFacade.getBookById(1);
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result);


            Assert.AreEqual(result.Id, (uint)1);
            Assert.AreEqual(result.Name, "Journey to the Center of the Earth");
            Assert.AreEqual(result.Price, 10.00m);
            Assert.AreEqual(result.Specifications.Originally_published, "25/11/1864");
            Assert.AreEqual(result.Specifications.Page_count, (uint)183);
            Assert.AreEqual(result.Specifications.Author[0], "Jules Verne");

        }

        [TestMethod]
        public void GetBookDTOByIDNotFound()
        {
            BookDTO? result = BookServicesFacade.getBookById(uint.MaxValue);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void QueryBookDTOList()
        {
            BookQuery query = new BookQuery
            {
                Title = "Harry Potter",
                MinPrice = 7.00m,
                MaxPrice = 8.00m,
                StartPublishDate = new DateTime(1999, 1, 1),
                EndPublishDate = new DateTime(2001, 1, 1),
                MinPageCount = 600,
                MaxPageCount = 700,
                Author = new List<string> { "J. K. Rowling" },
                Illustrator = new List<string> { "Mary GrandPré" },
                Genre = new List<string> { "Fantasy Fiction" }
            };

            IEnumerable<BookDTO> result = BookServicesFacade.queryBookList(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(result.First().Id, (uint)3);
        }

    }
}
