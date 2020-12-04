using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {

            // -------------------------------------
            // All sorting methods are in the sorting class, File: Sorting.cs

            DoubleLinkedList<int> MyDoubleLinkedList = new DoubleLinkedList<int>();

            MyDoubleLinkedList.Append(14);
            MyDoubleLinkedList.Append(11);
            MyDoubleLinkedList.Append(6);
            MyDoubleLinkedList.Append(9);
            MyDoubleLinkedList.Append(15);
            MyDoubleLinkedList.Append(15);
            MyDoubleLinkedList.Append(7);
            MyDoubleLinkedList.Append(8);
            MyDoubleLinkedList.Append(8);
            MyDoubleLinkedList.Append(11);
            MyDoubleLinkedList.Append(6);
            MyDoubleLinkedList.Append(9);
            MyDoubleLinkedList.Append(18);
            MyDoubleLinkedList.Append(15);
            MyDoubleLinkedList.Append(7);
            MyDoubleLinkedList.Append(8);


            // -------------------------------------
            // BUBBLE SORT - Extension method

            // uncomment to test
            // MyDoubleLinkedList.BubbleSort();

            // -------------------------------------
            // SELECTION SORT - Extension method

            // uncomment to test
            // MyDoubleLinkedList.SelectionSort();

            // -------------------------------------
            // INSERTION SORT - Extension method

            // uncomment to test
            // MyDoubleLinkedList.InsertionSort();

            // -------------------------------------
            // MERGE SORT SORT - Abstract Method that returns the sorted list
            // uncomment to test
            // MyDoubleLinkedList = Sorting.MergeSort(MyDoubleLinkedList);


            // -------------------------------------
            // QUICK SORT - Abstact method that sort the list passed to it.

            // uncomment to test
            // Sorting.QuickSort(MyDoubleLinkedList, 0, MyDoubleLinkedList.Size() - 1);

            for (int i = 0; i< MyDoubleLinkedList.Size(); i ++)
            {
                Console.WriteLine(MyDoubleLinkedList.Get(i));
            }
        }
    }
}
