namespace katas.LinkedList
{
    public class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            ListNode prev = null;
            ListNode next = head.next;

            while (next != null)
            {
                head.next = prev;
                prev = head;
                head = next;
                next = head.next;
            }

            head.next = prev;
            
            return head;
        }
    }

    // Definition for singly-linked list.
    public class ListNode
    {
        public ListNode next;
        public int val;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}