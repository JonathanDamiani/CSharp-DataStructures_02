using System;
namespace Sorting
{
    // Linked List node the inherent from node.
    // It has the nextNode, the previous node
    // The Single linked list just use the nextNode.
    // The Double Linked list use both
    public class LinkedListNode <T> : Node<T>
    {
        // Crete a next node to track the next of this.
        public LinkedListNode<T> nextNode;
        public LinkedListNode<T> previousNode;

        // Contructor to set the data 
        public LinkedListNode(T data)
        {
            this.data = data;
        }
    }
}
