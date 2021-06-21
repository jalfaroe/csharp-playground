using System.Linq;
using DataStructures.DoublyLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.DoublyLinkedList
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void InitalizeEmptyTest()
        {
            var ints = new DoublyLinkedList<int>();
            Assert.AreEqual(0, ints.Count);
        }

        [TestMethod]
        public void AddHeadTest()
        {
            var ints = new DoublyLinkedList<int>();
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
            var ints = new DoublyLinkedList<int>();
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
            var delete1to10 = create(1, 10);
            Assert.AreEqual(10, delete1to10.Count);

            for (var i = 1; i <= 10; i++)
            {
                Assert.IsTrue(delete1to10.Remove(i));
                Assert.IsFalse(delete1to10.Remove(i));
            }

            Assert.AreEqual(0, delete1to10.Count);

            var delete10to1 = create(1, 10);
            Assert.AreEqual(10, delete10to1.Count);

            for (var i = 10; i >= 1; i--)
            {
                Assert.IsTrue(delete10to1.Remove(i));
                Assert.IsFalse(delete10to1.Remove(i));
            }

            Assert.AreEqual(0, delete10to1.Count);
        }

        [TestMethod]
        public void RemoveMiddle()
        {
            var del = create(1, 10);
            del.Remove(5);

            Assert.AreEqual(9, del.Count);
            Assert.IsTrue(del.Contains(4));
            Assert.IsFalse(del.Contains(5));
            Assert.IsTrue(del.Contains(6));

            AssertArraysSame(del.ToArray(), new[] {1, 2, 3, 4, 6, 7, 8, 9, 10});
        }

        [TestMethod]
        public void ContainsTest()
        {
            var ints = create(1, 10);
            for (var i = 1; i <= 10; i++) Assert.IsTrue(ints.Contains(i));

            Assert.IsFalse(ints.Contains(0));
            Assert.IsFalse(ints.Contains(11));
        }

        [TestMethod]
        public void ReverseIteratorTest()
        {
            var ints = create(1, 10);
            var expected = 10;
            foreach (var actual in ints.GetReverseEnumerator()) Assert.AreEqual(expected--, actual);
        }

        private DoublyLinkedList<int> create(int start, int end)
        {
            var ints = new DoublyLinkedList<int>();
            for (var i = start; i <= end; i++) ints.AddTail(i);

            return ints;
        }

        private void AssertArraysSame(int[] actual, int[] expected)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i], string.Format("Incorrect value at index {0}", i));
        }
    }
}