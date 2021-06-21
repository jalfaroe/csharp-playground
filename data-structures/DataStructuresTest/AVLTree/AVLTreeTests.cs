using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataStructures.AVLTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.AVLTree
{
    [TestClass]
    public class AVLTreeTests
    {
        #region EnumerationTests

        [TestMethod]
        public void Enumerator_Of_Single()
        {
            var tree = new AVLTree<int>();

            foreach (var item in tree) Assert.IsTrue(false, "An empty tree should not enumerate any values");

            Assert.IsFalse(tree.Contains(10), "Tree should not contain 10 yet");

            tree.Add(10);

            Assert.IsTrue(tree.Contains(10), "Tree should contain 10");

            var count = 0;
            foreach (var item in tree)
            {
                count++;
                Assert.AreEqual(1, count);
                Assert.AreEqual(10, item);
            }
        }

        [TestMethod]
        public void LeftRotation_Basic()
        {
            var tree = new AVLTree<int>();

            //  1
            //   \
            //    2
            //     \
            //      3
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void RightRotation_Basic()
        {
            var tree = new AVLTree<int>();

            //      3
            //     /
            //    2
            //   /
            //  1
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void LeftRightRotation_Basic()
        {
            var tree = new AVLTree<int>();

            //  1
            //   \
            //    3
            //   /
            //  2
            tree.Add(1);
            tree.Add(3);
            tree.Add(2);

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void RightLeftRotation_Basic()
        {
            var tree = new AVLTree<int>();

            //   3
            //  /
            // 1
            //  \
            //   2
            tree.Add(3);
            tree.Add(1);
            tree.Add(2);

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void Add_And_Remove_1k_Unique_Items()
        {
            var tree = new AVLTree<int>();
            var items = new List<int>();

            // add random unique items to the tree
            var rng = new Random();
            while (items.Count < 1000)
            {
                var next = rng.Next();
                if (!items.Contains(next))
                {
                    items.Add(next);
                    tree.Add(next);

                    Assert.AreEqual(items.Count, tree.Count);
                }
            }

            // make sure they all exist in the tree
            foreach (var value in items)
                Assert.IsTrue(tree.Contains(value), "The tree does not contain the expected value " + value);

            // remove the item from the tree and make sure it's gone
            foreach (var value in items)
            {
                Assert.IsTrue(tree.Remove(value), "The tree does not contain the expected value " + value);
                Assert.IsFalse(tree.Contains(value), "The tree should not have contained the value " + value);
                Assert.IsFalse(tree.Remove(value), "The tree should not have contained the value " + value);
            }

            // now make sure the tree is empty
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void Rotation_Complexish()
        {
            var tree = new AVLTree<int>();

            //      3
            //     /
            //    2
            //   /
            //  1
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item));
            Assert.AreEqual(index, expected.Length);

            //   2
            //  / \
            // 1   3
            //      \
            //       4

            tree.Add(4);

            expected = new[] {2, 1, 3, 4};
            index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item));
            Assert.AreEqual(index, expected.Length);

            //   2
            //  / \
            // 1   3
            //      \
            //       4
            //        \
            //         5

            tree.Add(5);

            //   2
            //  / \
            // 1   4
            //    /  \
            //   3    5

            expected = new[] {2, 1, 4, 3, 5};
            index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item));
            Assert.AreEqual(index, expected.Length);

            //   2
            //  / \
            // 1   4
            //    /  \
            //   3    5
            //         \
            //          6

            tree.Add(6);

            //     4
            //    / \
            //   2   5
            //  / \   \
            // 1   3   6

            expected = new[] {4, 2, 1, 3, 5, 6};
            index = 0;

            tree.PreOrderTraversal(item => Debug.WriteLine(item));

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item));
            Assert.AreEqual(index, expected.Length);
        }

        [TestMethod]
        public void InOrder_Delegate()
        {
            var tree = new AVLTree<int>();

            var expected = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                tree.Add(i);
                expected.Add(i);
            }

            var index = 0;

            tree.InOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        #endregion

        #region Remove tests

        [TestMethod]
        public void Remove_Head()
        {
            var tree = new AVLTree<int>();

            //     4
            //   /   \
            //  2     6
            // / \   / \
            //1   3 5   7
            //           \
            //            8


            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            tree.Remove(4);

            //     5
            //   /   \
            //  2     6
            // / \     \
            //1   3     7
            //           \
            //            8

            int[] expected = {1, 3, 2, 8, 7, 6, 5};

            var index = 0;
            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void Remove_Head_Line_Right()
        {
            var tree = new AVLTree<int>();

            // 1
            //  \
            //   2
            //    \
            //     3


            tree.Add(1);
            tree.Add(2);
            tree.Add(3);

            tree.Remove(1);

            // 2
            //  \
            //   3


            int[] expected = {3, 2};

            var index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void Remove_Head_Line_Left()
        {
            var tree = new AVLTree<int>();

            //     3
            //    /
            //   2
            //  /
            // 1


            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            tree.Remove(3);

            //   2
            //  /
            // 1

            int[] expected = {1, 2};

            var index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }


        [TestMethod]
        public void Remove_Head_Only_Node()
        {
            var tree = new AVLTree<int>();

            tree.Add(4);

            Assert.IsTrue(tree.Remove(4), "Remove should return true for found node");

            foreach (var item in tree) Assert.IsTrue(false, "An empty tree should not enumerate any values");
        }

        [TestMethod]
        public void Remove_Node_No_Left_Child()
        {
            var tree = new AVLTree<int>();

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            Assert.IsTrue(tree.Remove(5), "Remove should return true for found node");

            //         4
            //       /  \
            //      2     7
            //     / \   / \
            //    1   3  6  8

            int[] expected = {1, 3, 2, 6, 8, 7, 4};

            var index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void Remove_Node_Right_Leaf()
        {
            var tree = new AVLTree<int>();

            //         4
            //       /   \
            //      2     6
            //     / \   / \
            //    1   3 5   7
            //               \
            //               8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            Assert.IsTrue(tree.Remove(8), "Remove should return true for found node");

            //         4
            //       /   \
            //      2     6
            //     / \   / \
            //    1   3 5   7

            int[] expected = {1, 3, 2, 5, 7, 6, 4};

            var index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void Remove_Node_Left_Leaf()
        {
            var tree = new AVLTree<int>();

            //         4
            //       /   \
            //      2     6
            //     / \   / \
            //    1   3 5   7
            //               \
            //               8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            Assert.IsTrue(tree.Remove(1), "Remove should return true for found node");

            //        4
            //      /   \
            //    2      6
            //     \    / \
            //      3  5   7
            //              \
            //               8

            int[] expected = {3, 2, 5, 8, 7, 6, 4};

            var index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void Remove_Current_Right_Has_No_Left()
        {
            var tree = new AVLTree<int>();

            //       5 
            //     /   \
            //    3     7
            //   / \   / \
            //  2   4 6   8
            // /
            //1

            tree.Add(4);
            tree.Add(6);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(1);
            tree.Add(8);

            Assert.IsTrue(tree.Remove(4), "Remove should return true for found node");

            //     5 
            //   /   \
            //  2     7
            // / \   / \
            //1   3 6   8

            int[] expected = {1, 3, 2, 6, 8, 7, 5};

            var index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void Remove_Current_Has_No_Right()
        {
            var tree = new AVLTree<int>();

            //         4
            //       /   \
            //      2     8 
            //     / \    /
            //    1   3  6
            //          / \
            //         5   7   

            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
            tree.Add(8);
            tree.Add(6);
            tree.Add(7);
            tree.Add(5);

            Assert.IsTrue(tree.Remove(8), "Remove should return true for found node");

            //         4
            //       /   \
            //      2      6 
            //     / \    / \
            //    1   3  5   7

            int[] expected = {1, 3, 2, 5, 7, 6, 4};

            var index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void Remove_Current_Right_Has_Left()
        {
            var tree = new AVLTree<int>();

            //         4
            //       /    \
            //      2      6 
            //     / \    / \
            //    1   3  5   8
            //              /
            //             7

            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
            tree.Add(6);
            tree.Add(5);
            tree.Add(8);
            tree.Add(7);

            Assert.IsTrue(tree.Remove(6), "Remove should return true for found node");

            //         4
            //       /    \
            //      2      7 
            //     / \    / \
            //    1   3  5   8

            int[] expected = {1, 3, 2, 5, 8, 7, 4};

            var index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item));
        }

        [TestMethod]
        public void Remove_From_Empty()
        {
            var tree = new AVLTree<int>();
            Assert.IsFalse(tree.Remove(10));
        }

        [TestMethod]
        public void Remove_Missing_From_Tree()
        {
            var tree = new AVLTree<int>();

            //         4
            //       /   \
            //      2     8 
            //     / \    /
            //    1   3  6
            //          / \
            //         5   7   

            int[] values = {4, 2, 1, 3, 8, 6, 7, 5};

            foreach (var i in values)
            {
                Assert.IsFalse(tree.Contains(10), "Tree should not contain 10");
                tree.Add(i);
            }
        }

        #endregion
    }
}