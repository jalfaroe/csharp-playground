using DataStructures.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.Queue
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Queue_EnqueueDequeue1to10()
        {
            var queue = new Queue<int>();

            for (var i = 0; i < 10; i++) queue.Enqueue(i);

            Assert.AreEqual(10, queue.Count);

            for (var expected = 0; expected < 10; expected++)
            {
                Assert.AreEqual(expected, queue.Peek());
                Assert.AreEqual(expected, queue.Dequeue());
            }

            Assert.AreEqual(0, queue.Count);
        }
    }
}