namespace Sorting
{
    static public class Sorting
    {
        // Bubble sort, compare the n element with n + 1, if it is greater swap the values
        // do it with all elements until the list is sorted.
        // Pretty bad performance
        // As extension method
        public static DoubleLinkedList<int> BubbleSort(this DoubleLinkedList<int> myList)
        {
            int temp;

            // Loop the list comparing every element on the list
            // an swaping them, putting the smaller on the left side.
            for (int i = 0; i < myList.Size() - 1; i++)
            {
                for (int j = 0; j < myList.Size() - 1; j++)
                {
                    if (myList.Get(j) > myList.Get(j+1))
                    {
                        temp = myList.Get(j);
                        myList.Replace(myList.Get(j + 1), j);
                        myList.Replace(temp, j + 1);

                    }
                }
            }
            return myList;

        }

        // Selection Sort, select the smallest element on the list then put it on the first place
        // then find the second smallest and put on the second place, repeat until everything is sorted
        // Still bad performance
        // As extension method
        public static DoubleLinkedList<int> SelectionSort(this DoubleLinkedList<int> myList)
        {
            int temp;
            int smallestValue;

            // Loop the list and changing the value in which position to the smaller value 
            for (int i = 0; i < myList.Size() - 1; i++)
            {
                smallestValue = i;

                // Loop to find the smallest value
                for (int j = i + 1; j < myList.Size(); j++)
                {
                    if ( myList.Get(j) < myList.Get(smallestValue))
                    {
                        smallestValue = j;
                    }
                }

                // Doing the element swap
                temp = myList.Get(i);
                myList.Replace(myList.Get(smallestValue), i);
                myList.Replace(temp, smallestValue);

            }

            return myList;
        }

        // Insertion Sort, get the element and compare with the previous one and swap then if the number is 
        // smaller than it previous one. Repeat until is done, the thing is if the previous element is alreary small,
        // it stop the iteration so, it does not need to compare every element.
        // Better performance but still bad
        // As extension method
        public static void InsertionSort(this DoubleLinkedList<int> myList)
        {
            // Looping the list
            for (int i = 0; i < myList.Size() - 1; i++)
            {
                // Index to check, starting in the second element
                int indexToCheck = i + 1;

                // Loop comparing the element with it previous one and swaping when it is smaller
                // starting looping  indexToCheck, and decrease until reaches 0
                while( indexToCheck > 0 && myList.Get(indexToCheck) < myList.Get(indexToCheck - 1))
                {
                    int temp = myList.Get(indexToCheck - 1);
                    myList.Replace(myList.Get(indexToCheck), indexToCheck - 1);
                    myList.Replace(temp, indexToCheck);
                    indexToCheck--;
                }
            }
        }

        // Merge sort, divide the list until it are only size 1 list, so it will be sorted
        // them merge the list again but comparing the values sorting during the merge
        // As simple static method
        // Good performance but not the best yet
        public static DoubleLinkedList<int> MergeSort(DoubleLinkedList<int> myList)
        {
            // Breaking the recursion
            if (myList.Size() == 1)
            {
                return myList;
            }

            // Create new lists to be the the splited lists of the main list
            DoubleLinkedList<int> leftList = new DoubleLinkedList<int>();
            DoubleLinkedList<int> rightList = new DoubleLinkedList<int>();

            // Get the sizes of the lists
            int leftListSize = myList.Size() / 2;
            int rightListSize = myList.Size() - leftListSize;

            // Append the values on the lists accoring with it sides
            for (int i = 0; i < leftListSize; i++)
            {
                leftList.Append(myList.Get(i));
            }

            for (int i = 0; i < rightListSize; i++)
            {
                rightList.Append(myList.Get(i + leftListSize));
            }

            // Calling the recursion on both lists
            leftList = MergeSort(leftList);
            rightList = MergeSort(rightList);

            // Return the sorted merged list.
            return MergeList(leftList, rightList); ;
        }

        // Function to merge two list into one list in sorted order. 
        public static DoubleLinkedList<int> MergeList(DoubleLinkedList<int> listA, DoubleLinkedList<int> listB)
        {
            // Create new list to be the merged one
            DoubleLinkedList<int> mergedList = new DoubleLinkedList<int>();

            // Getting the size of the list being the sum of the sizes of the two parameters list
            int mergedListSize = listA.Size() + listB.Size();

            // Started Index
            int mergedIndex = 0;

            // Index to check in the list
            int indexA = 0;
            int indexB = 0;

            // Loop until fill all the merged list with the values of the other list
            // increasing the merged index until it stay less than the size of the
            // merged ist
            while (mergedIndex < mergedListSize)
            {
                // Check which values is smaller and adding to the list
                // increase the index

                // If the index of B is the size of the list, so it reach it max value
                // so everything will be on the left list
                if (indexB == listB.Size ())
                {
                    mergedList.Append(listA.Get(indexA));
                    indexA++;
                    mergedIndex++;
                    continue;
                }

                // If the index of A is the size of the list, so it reach it max value
                // so everything will be on the left list
                if (indexA == listA.Size())
                {
                    mergedList.Append(listB.Get(indexB));
                    indexB++;
                    mergedIndex++;
                    continue;
                }

                // Sorting the values on the list and increasing the indexes
                if (listA.Get(indexA) < listB.Get(indexB))
                {
                    mergedList.Append(listA.Get(indexA));
                    indexA++;
                }
                else
                {
                    mergedList.Append(listB.Get(indexB));
                    indexB++;
                }
                // Do it until the merged index reach the max.
                mergedIndex++;
            }

            // Return the merged list.
            return mergedList;
        }

        // Quick Sort, find a pivot point in the list, starting from the first or last element
        // Compare the pivot with the others elements unit find it place on the list, then swap
        // the element, divide the list in two from the pivot and do the sort again,
        // until everyting is sorted
        // Best performance between the sorting method so far
        public static void QuickSort(DoubleLinkedList<int> myList, int startIndex, int endIndex)
        {
            // If the startIndex is less than the end Index, keep sorting
            // Base case
            if (startIndex < endIndex)
            {
               // Get the pivot to test in the right position 
               int pivot = QuickSortPartition(myList, startIndex, endIndex);

                // If pivot is greater than 1, call the quick sort again with the
                // start index as the startIndex, and the pivot from  the sorted partition
                // as the endindex
                if (pivot > 1)
                {
                    QuickSort(myList, startIndex, pivot - 1);
                }

                // If pivot + 1 is greater than the endIndex, call the quick sort again with the
                // pivot + 1 as the startIndex, and the endIndex as the endIndex

                if ( pivot + 1 < endIndex)
                {
                    QuickSort(myList, pivot + 1, endIndex );
                }
            }
        }

        // Sorting the divided partion for the quick sort
        // Just to be more readable. Could be inside the sort
        public static int QuickSortPartition (DoubleLinkedList<int> myList, int leftSide, int rightSide)
        {
            // Get the pivot value to compare
            int pivot = myList.Get(leftSide);

            // Temp value to store values in the swap part
            int tempValue;

            // Loop until done
            while (true)
            {
                // While the value of the left side index is small than the pivot
                // change the position of the left to check to the next
                while (myList.Get(leftSide) < pivot)
                {
                    leftSide++;
                }

                // While the value of the right side index is greater than the pivot
                // change the position of the right to check to the previous
                while (myList.Get(rightSide) > pivot)
                {
                    rightSide--;
                }

                // If leftside is less the the right
                if (leftSide < rightSide)
                {

                    // if both are the same value, change the position to the rightside
                    if (myList.Get(leftSide) == myList.Get(rightSide))
                    {
                        rightSide --;
                    }

                    // Change the values to the right position
                    // It basically putting the smaller elements in the left side of the pivot
                    // and the gretest elements on the right side
                    tempValue = myList.Get(leftSide);
                    myList.Replace(myList.Get(rightSide), leftSide);
                    myList.Replace(tempValue, rightSide);
                }

                else
                {
                    return rightSide;
                }
            }
        }
    }
}
