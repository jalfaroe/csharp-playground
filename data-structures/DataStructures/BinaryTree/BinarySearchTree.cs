using System.Diagnostics;

namespace DataStructures.BinaryTree
{
    /// <summary>
    ///     Binary Search Tree:
    ///     1. If the left subtree of any node is not empty, the value of all nodes on the left subtree is less than the value
    ///     of its root node;
    ///     2. If the right subtree of any node is not empty, the value of all nodes on the right subtree is greater than the
    ///     value of its root node;
    ///     3. The left subtree and the right subtree of any node are also binary search trees.
    /// </summary>
    public class BinarySearchTree
    {
        public Node Root { get; private set; }

        /// <summary>
        ///     The inserted nodes are compared from the root node and the smaller than the root node is compared with the left
        ///     subtree of the root node, otherwise, compared with the right subtree until the left subtree is empty or the right
        ///     subtree is empty, then is inserted.
        /// </summary>
        public void Insert(int data)
        {
            if (Root is null)
            {
                Root = new Node(data);
                return;
            }

            Insert(Root, data);
        }

        private static void Insert(Node parent, int data)
        {
            if (data < parent.Data)
            {
                if (parent.Left is null) parent.Left = new Node(data);
                else Insert(parent.Left, data);
            }
            else
            {
                if (parent.Right is null) parent.Right = new Node(data);
                else Insert(parent.Right, data);
            }
        }

        // In-order traversal: left subtree -> root node -> right subtree 
        public void InOrder(Node root)
        {
            if (root == null) return;

            InOrder(root.Left);
            Debug.Write(root.Data + ", ");
            InOrder(root.Right);
        }

        // Pre-order traversal : root node -> left subtree -> right subtree
        public void PreOrder(Node root)
        {
            if (root == null) return;

            Debug.Write(root.Data + ", ");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }

        // Post-order traversal: : right subtree -> root node -> left subtree
        public void PostOrder(Node root)
        {
            if (root == null) return;

            PostOrder(root.Left);
            PostOrder(root.Right);
            Debug.Write(root.Data + ", ");
        }

        /// <summary>
        ///     Minimum value: The small value is on the left child node, as long as the recursion traverses the left child until
        ///     be empty, the current node is the minimum node.
        /// </summary>
        public int GetMinValue(Node node)
        {
            if (node is null) return 0;
            if (node.Left is null) return node.Data;

            return GetMinValue(node.Left);
        }

        /// <summary>
        ///     Maximum value: The large value is on the right child node, as long as the recursive traversal is the right child
        ///     until be empty, the current node is the largest node.
        /// </summary>
        public int GetMaxValue(Node node)
        {
            if (node is null) return 0;
            if (node.Right is null) return node.Data;

            return GetMaxValue(node.Right);
        }
    }
}