using BookAPIagro.Controllers;
using BookAPIagro.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBookAPIagro.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {

        [TestMethod]
        public void GetAllBooksTest()
        {
            // Arrange
            BooksController controller = new BooksController();

            // Act
            IActionResult result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
