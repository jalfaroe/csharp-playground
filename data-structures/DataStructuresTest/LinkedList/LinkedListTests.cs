using DataStructures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.LinkedList
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void InitalizeEmptyTest()
        {
            var ints = new LinkedList<int>();
            Assert.AreEqual(0, ints.Count);
        }

        [TestMethod]
        public void AddHeadTest()
        {
            var ints = new LinkedList<int>();
            for (var i = 1; i <= 5; i++)
            {
                ints.AddHead(i);
                Assert.AreEqual(i, ints.Count);
            }

            var expected = 5;
            foreach (var x in ints) Assert.AreEqual(expected--, x);
        }

        [TestMethod]
        public void AddTailTest()
        {
            var ints = new LinkedList<int>();
            for (var i = 1; i <= 5; i++)
            {
                ints.AddTail(i);
                Assert.AreEqual(i, ints.Count);
            }

            var expected = 1;
            foreach (var x in ints) Assert.AreEqual(expected++, x);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var delete1to10 = Create(1, 10);
            Assert.AreEqual(10, delete1to10.Count);

            for (var i = 1; i <= 10; i++)
            {
                Assert.IsTrue(delete1to10.Remove(i));
                Assert.IsFalse(delete1to10.Remove(i));
            }

            Assert.AreEqual(0, delete1to10.Count);

            var delete10to1 = Create(1, 10);
            Assert.AreEqual(10, delete10to1.Count);

            for (var i = 10; i >= 1; i--)
            {
                Assert.IsTrue(delete10to1.Remove(i));
                Assert.IsFalse(delete10to1.Remove(i));
            }

            Assert.AreEqual(0, delete10to1.Count);
        }

        [TestMethod]
        public void ContainsTest()
        {
            var ints = Create(1, 10);
            for (var i = 1; i <= 10; i++) Assert.IsTrue(ints.Contains(i));

            Assert.IsFalse(ints.Contains(0));
            Assert.IsFalse(ints.Contains(11));
        }

        private static LinkedList<int> Create(int start, int end)
        {
            var ints = new LinkedList<int>();
            for (var i = start; i <= end; i++) ints.AddTail(i);

            return ints;
        }
    }
}