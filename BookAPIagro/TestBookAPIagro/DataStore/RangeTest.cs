using BookAPIagro.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBookAPIagro.DataStore
{
    [TestClass]
    public class RangeTest
    {
        [TestMethod]
        public void RangeCreationTest()
        {
            Range<int> range = new Range<int>(1, 10);
            Assert.AreEqual(range.Min, 1);
            Assert.AreEqual(range.Max, 10);
        }

        [TestMethod]
        public void RangeContainsIntegerValueTest()
        {
            Range<int> range = new Range<int>(1, 10);
            Assert.AreEqual(range.Min, 1);
            Assert.AreEqual(range.Max, 10);
            Assert.IsFalse(range.Contains(0));
            Assert.IsTrue(range.Contains(1));
            Assert.IsTrue(range.Contains(5));
            Assert.IsTrue(range.Contains(10));
            Assert.IsFalse(range.Contains(11));
        }

        [TestMethod]
        public void RangeContainsDecimalValueTest()
        {
            Range<decimal> range = new Range<decimal>(1.0m, 10.0m);
            Assert.AreEqual(range.Min, 1.0m);
            Assert.AreEqual(range.Max, 10.0m);
            Assert.IsFalse(range.Contains(0.0m));
            Assert.IsTrue(range.Contains(1.0m));
            Assert.IsTrue(range.Contains(5.0m));
            Assert.IsTrue(range.Contains(10.0m));
            Assert.IsFalse(range.Contains(11.0m));
        }

        [TestMethod]
        public void RangeContainsDateOnlyValueTest()
        {
            Range<DateOnly> range = new Range<DateOnly>(new DateOnly(2021, 1, 1), new DateOnly(2021, 12, 31));
            Assert.AreEqual(range.Min, new DateOnly(2021, 1, 1));
            Assert.AreEqual(range.Max, new DateOnly(2021, 12, 31));
            Assert.IsFalse(range.Contains(new DateOnly(2020, 12, 31)));
            Assert.IsTrue(range.Contains(new DateOnly(2021, 1, 1)));
            Assert.IsTrue(range.Contains(new DateOnly(2021, 6, 1)));
            Assert.IsTrue(range.Contains(new DateOnly(2021, 12, 31)));
            Assert.IsFalse(range.Contains(new DateOnly(2022, 1, 1)));
        }
        [TestMethod]
        public void RangeWithUnboundedMinContainsValueTest()
        {
            Range<int> range = new Range<int>(null, 10);
            Assert.AreEqual(range.Min, null);
            Assert.AreEqual(range.Max, 10);
            Assert.IsTrue(range.Contains(-1));
            Assert.IsTrue(range.Contains(0));
            Assert.IsTrue(range.Contains(1));
            Assert.IsTrue(range.Contains(5));
            Assert.IsTrue(range.Contains(10));
            Assert.IsFalse(range.Contains(11));
        }

        [TestMethod]
        public void RangeWithUnboundedMaxContainsValueTest()
        {
            Range<int> range = new Range<int>(1, null);
            Assert.AreEqual(range.Min, 1);
            Assert.AreEqual(range.Max, null);
            Assert.IsFalse(range.Contains(0));
            Assert.IsTrue(range.Contains(1));
            Assert.IsTrue(range.Contains(5));
            Assert.IsTrue(range.Contains(10));
            Assert.IsTrue(range.Contains(11));
        }
    }
}
