using BookAPIagro.Entities;
using BookAPIagro.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBookAPIagro.UseCases
{
    [TestClass]
    public class FreteCalculatorTest
    {
        [TestMethod]
        public void calculateFreteTest()
        {
            var book = new Book(
                        1,
                        "Journey to the Center of the Earth",
                        10.00m,
                        new DateOnly(1864, 11, 25),
                        183,
                        new List<Author> { new Author("Jules Verne") },
                        new List<Illustrator> { new Illustrator("Édouard Riou") },
                        new List<Genre>
                        {
                            new Genre("Science Fiction"),
                            new Genre("Adventure fiction")
                        }
                    );
            Assert.AreEqual(2.00m, book.CalculateFrete());

        }
    }
}
