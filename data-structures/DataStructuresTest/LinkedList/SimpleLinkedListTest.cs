using DataStructures.LinkedList;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.LinkedList
{
    [TestClass]
    public class SimpleLinkedListTest
    {
        [TestMethod]
        public void AddFirstTest()
        {
            // Arrange
            var list = new SimpleLinkedList<int>();
            list.AddHead(1);
            list.AddHead(2);
            list.AddHead(3);
            list.AddHead(4);

            // Act => Assert
            list.Head.Should().Be(4);
            list.Tail.Should().Be(1);
            list.Count.Should().Be(4);
        }

        [TestMethod]
        public void AddTailTest()
        {
            // Arrange
            var list = new SimpleLinkedList<int>();
            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);
            list.AddTail(4);

            // Act => Assert
            list.Head.Should().Be(1);
            list.Tail.Should().Be(4);
            list.Count.Should().Be(4);
        }

        [TestMethod]
        public void FindValueTest()
        {
            // Arrange
            var list = CreateList();

            // Act => Assert
            list.Find(1).Should().BeTrue();
            list.Find(4).Should().BeTrue();
            list.Find(5).Should().BeFalse();
        }

        public SimpleLinkedList<int> CreateList()
        {
            var list = new SimpleLinkedList<int>();

            list.AddHead(1);
            list.AddHead(2);
            list.AddHead(3);
            list.AddHead(4);

            return list;
        }
    }
}