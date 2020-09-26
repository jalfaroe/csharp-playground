using DataStructures.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.BinaryTree
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void Insert_ConstructValidBinarySearchTree()
        {
            // Arrange => Act
            var bst = CreateBinaryTree();

            // Assert
            bst.Root.Data.Should().Be(60);
            bst.Root.Left.Data.Should().Be(40);
            bst.Root.Right.Data.Should().Be(80);
            bst.Root.Right.Left.Data.Should().Be(70);
            bst.Root.Right.Right.Data.Should().Be(90);
            bst.Root.Left.Left.Data.Should().Be(20);
            bst.Root.Left.Right.Data.Should().Be(50);
            bst.Root.Left.Left.Left.Data.Should().Be(10);
            bst.Root.Left.Left.Right.Data.Should().Be(30);
        }

        [TestMethod]
        public void InOrder_ProcessInOrderTraversal()
        {
            var bst = CreateBinaryTree();
            bst.InOrder(bst.Root);
        }

        [TestMethod]
        public void PreOrder_ProcessPreOrderTraversal()
        {
            var bst = CreateBinaryTree();
            bst.PreOrder(bst.Root);
        }

        [TestMethod]
        public void PostOrder_ProcessPostOrderTraversal()
        {
            var bst = CreateBinaryTree();
            bst.PostOrder(bst.Root);
        }

        [TestMethod]
        public void GetMinValue_ReturnMinValue()
        {
            var bst = CreateBinaryTree();
            bst.GetMinValue(bst.Root).Should().Be(10);
        }

        [TestMethod]
        public void GetMaxValue_ReturnMaxValue()
        {
            var bst = CreateBinaryTree();
            bst.GetMaxValue(bst.Root).Should().Be(90);
        }

        private static BinarySearchTree CreateBinaryTree()
        {
            var bst = new BinarySearchTree();
            bst.Insert(60);
            bst.Insert(40);
            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(30);
            bst.Insert(50);
            bst.Insert(80);
            bst.Insert(70);
            bst.Insert(90);

            return bst;
        }
    }
}