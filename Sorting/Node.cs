using System;
namespace Sorting
{
    // Base node class.
    public class Node <T>
    {
        // Data template accepts any type of data.
        public T data;

        // Contructor
        public Node() { }

        // Contructor setting the data
        public Node(T data)
        {
            this.data = data;
        }
    }
}
