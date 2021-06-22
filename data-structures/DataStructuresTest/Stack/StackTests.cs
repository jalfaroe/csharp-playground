using System;
using DataStructures.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.Stack
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Stack_Success_Cases()
        {
            foreach (int[] testData in GetTestData())
            {
                var stack = new Stack<int>();

                for (var i = 0; i < testData.Length; i++)
                {
                    Assert.AreEqual(stack.Count, i, "The stack count is off");

                    stack.Push(testData[i]);

                    Assert.AreEqual(stack.Count, i + 1, "The stack count is off");

                    Assert.AreEqual(testData[i], stack.Peek(), "The recently pushed value is not peeking");
                }

                Assert.AreEqual(testData.Length, stack.Count, "The end count was not as expected");

                for (var i = testData.Length - 1; i >= 0; i--)
                {
                    var expected = testData[i];
                    Assert.AreEqual(expected, stack.Peek(), "The peeked value was not expected");
                    Assert.AreEqual(expected, stack.Pop(), "The popped value was not expected");
                    Assert.AreEqual(i, stack.Count, "The popped value was not expected");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_From_Empty_Throws()
        {
            var s = new Stack<int>();
            s.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_From_Empty_Throws_After_Push()
        {
            var s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_From_Empty_Throws()
        {
            var s = new Stack<int>();
            s.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_From_Empty_Throws_After_Push()
        {
            var s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Peek();
        }

        private static object[] GetTestData()
        {
            object[] Push_TestData =
            {
                new int[0],
                new[] {0},
                new[] {0, 1},
                new[] {0, 1, 2},
                new[] {0, 1, 2, 3},
                new[] {0, 1, 2, 3, 4}
            };

            return Push_TestData;
        }
    }
}