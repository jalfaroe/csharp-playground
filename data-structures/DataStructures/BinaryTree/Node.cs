namespace DataStructures.BinaryTree
{
    public class Node
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}