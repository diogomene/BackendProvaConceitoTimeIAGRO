using BookAPIagro.DataAccess;
using BookAPIagro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBookAPIagro.DataAccess
{
    [TestClass]
    public class JsonParserTest
    {
        [TestMethod]
        public void ParseJsonNotFoundTest()
        {
            string jsonPath = "nonexistententbeautifulhorsefromiagrocgmsjson.json";
            BookDTO? result = JSONParser<BookDTO>.ParseJson(jsonPath);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseJsonTest()
        {
            string jsonPath = "TestsData/books.json";
            List<BookDTO>? result = JSONParser<List<BookDTO>>.ParseJson(jsonPath);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 5);
        }
    }
}
