using System;
namespace Sorting
{
    // Create Double Linked List data structure. Every node keep track of itself,
    // the next one to it and also the previous one,we can get any node,
    // index of the list and remove any node in every
    public class DoubleLinkedList <T> : SingleLinkedList<T>
    {
        public DoubleLinkedList() 
        {
        }

        // Appends entry to end of list.
        public override void Append(T entry)
        {
            // Check if head is null, if it is create a node with the entry value
            // as the head
            if (head == null)
            {
                head = new LinkedListNode<T>(entry);
            }
            // If not put the new node at the last node of the list
            else
            {
                // Current node to track each node on the list, starting on the
                // head
                LinkedListNode<T> currentNode = head;
                LinkedListNode<T> previousNode = head;

                // Loop through the list change the current node value to its
                // next value
                while (true)
                {
                    // When the current node is null, set it to the a new node
                    // so set the previous node next to be the current node
                    // and the previous of the current to be the previous node
                    if (currentNode == null)
                    {
                        currentNode = new LinkedListNode<T>(entry);
                        previousNode.nextNode = currentNode;
                        currentNode.previousNode = previousNode;
                        break;
                    }
                    else
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.nextNode;
                    }
                }
            }
        }

        // Insert entry at supplied index, return true on success, false on error.
        public override bool Insert(T entry, int index)
        {
            // Creting the counter to track the index on the list.
            int counter = 0;

            // Creating nodes to keep track of the current node, and the previuos
            // node on the list.
            LinkedListNode<T> currentNode = head;
            LinkedListNode<T> previousNode = head;

            // new node to insert on the list
            LinkedListNode<T> newNode = new LinkedListNode<T>(entry);

            // Check if head is null and if the index is different of 0,
            // there no way to add a node if there is no head, unless you adding
            // it on the head
            if (head == null && index != 0)
            {
                return false;
            }
            // Check if the index is out of range.
            else if (index > Size() || index < 0)
            {
                return false;
            }
            // Adding the node to list
            else
            {
                // Loop until add and them break the loop.
                while (true)
                {
                    // If it find the index passed by the user 
                    if (counter == index)
                    {
                        // If the index is 0 add it to the head
                        if (index == 0)
                        {
                            // if head is null, make the new node the head
                            if (head == null)
                            {
                                head = newNode;
                            }
                            // if head is not null make the new node the head
                            // then the next of the new node to point to the
                            // old head and the previous of the old head to be
                            // the new head.
                            else
                            {
                                head.previousNode = newNode;
                                newNode.nextNode = head;
                                head = newNode;
                            }
                        }
                        // If the index is not 0
                        // Make the next of previous node be the new node
                        // then the newNode next be the current node
                        // inserting the new node between the previous and the
                        // current, and then update the previous of the current
                        // node to be the new node and the next of the previous
                        // to be the new node as well
                        else
                        {
                            newNode.previousNode = previousNode;
                            previousNode.nextNode = newNode;
                            currentNode.previousNode = newNode;
                            newNode.nextNode = currentNode;
                        }

                        return true;
                    }
                    // If it not the index to insert yet, increase the counter
                    // make the previous one be the current one and the current
                    // be the next of itself. 
                    else
                    {
                        counter++;
                        previousNode = currentNode;
                        currentNode = currentNode.nextNode;
                    }
                }
            }
        }

        // Remove entry at supplied index, return true on success
        public override bool Remove(int index)
        {

            int counter = 0;

            LinkedListNode<T> currentNode = head;
            LinkedListNode<T> previousNode = head;

            // Check if head is null 
            if (head == null)
            {
                throw new Exception("The list is empty");
            }
            // Check if the index is out of range
            else if (index >= Size() || index < 0)
            {
                throw new Exception("The index is out of range");
            }
            else
            {
                // Loot through the list until find the node the remove
                while (true)
                {
                    // If the counter is equal the index, it is the node to
                    // remove
                    if (counter == index)
                    {
                        // If the index is equal a 0, remove the head
                        if (index == 0)
                        {
                            // If the next node of the head is null
                            // make the head null
                            if (head.nextNode == null)
                            {
                                head = null;
                            }
                            // If the next node of the head is not null
                            // make the next of the head the new head,
                            // and the previous of the head to be null.
                            else
                            {
                                head = head.nextNode;
                                head.previousNode = null;
                            }

                        }
                        // If it is not the head remove the other node.
                        // Making the next of the previous to be the next of the
                        // current node.
                        else
                        {
                            // If the next of the current is null, make the
                            // previous of the current and the next of the
                            // previous node to be null.
                            if (currentNode.nextNode == null)
                            {
                                currentNode.previousNode = null;
                                previousNode.nextNode = null;
                            }
                            // If the next is not null, update the previous node
                            // of the next node of the current node to be the
                            // previous node.
                            else
                            {
                                previousNode.nextNode = currentNode.nextNode;
                                currentNode.nextNode.previousNode = previousNode;
                            }
                        }

                        return true;
                    }
                    // If is not the node to remove, add 1 to the counter
                    // and make the previous node the current one and the
                    // current node be the next of itself
                    else
                    {
                        counter++;
                        previousNode = currentNode;
                        currentNode = currentNode.nextNode;
                    }
                }
            }
        }
    }
}
