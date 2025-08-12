using System;

public class HeapSorter
{
    // Public method that sorts an array using Heap Sort algorithm
    public static void HeapSort(int[] arr)
    {
        if (arr == null)// If the array is null, throw an exception
            throw new ArgumentNullException(nameof(arr));

        if (arr.Length <= 1)  return; // If the array has 1 or fewer elements, it's already sorted
        // First, build a Max-Heap from the array
        BuildMaxHeap(arr);
        // Հիմա հերթով փոխանակում ենք ամենամեծ տարրը (index 0-ում է) վերջին էլեմենտի հետ
        // և փոքրացնում ենք heap-ի չափը՝ ամեն անգամ մեկո
        // Then extract elements from the heap one by one, from end to start
        for (int i = arr.Length - 1; i > 0; --i)
        {
            Swap(arr, 0, i);// Swap the root (maximum element) with the last element in the heap// Փոխանակում ենք arr[0]-ը (ամենամեծ տարրը) arr[i]-ի հետ
            Heapify(arr, 0, i); // Restore the Max-Heap property in the reduced heap // Կրկին կարգավորում ենք heap-ը, որպեսզի Max-Heap property-ն պահպանվի
        }
    }
    private static int GetLeft(int i)// Helper method to get the index of the left child of a given node
    {
        return 2 * i + 1;
    }
    private static int GetRight(int i)// Helper method to get the index of the right child of a given node
    {
        return 2 * i + 2;
    }

    private static void Swap(int[] arr, int i, int j) // Swaps the elements at index i and j in the array
    {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }

    // Max-Heap կարգավորող ռեկուրսիվ մեթոդ՝ սկսելով i ինդեքսից և մինչև տրված չափը (size)
    // Restores the Max-Heap property starting from index i up to size
    private static void Heapify(int[] arr, int i, int size)
    {
        // Սկզբում մեծագույն ինդեքսը համարվում է i ինդեքսը
        // Assume the largest is the current index
        int LargestIndex = i; 

        // Get indices of left and right children
        // Հաշվում ենք ձախ և աջ երեխաների ինդեքսները
        int LeftIndex = GetLeft(i);
        int RightIndex = GetRight(i);

        // If left child exists and is greater than the current largest, update LargestIndex
        // Եթե ձախ երեխան գտնվում է սահմանում և նրա արժեքը մեծ է ներկայիս մեծագույնից՝ թարմացնում ենք
        if (LeftIndex < size && arr[LargestIndex] > arr[LargestIndex])
        {
            LargestIndex = LeftIndex;
        }

        // If right child exists and is greater than the current largest, update LargestIndex
        // Եթե աջ երեխան գտնվում է սահմանում և նրա արժեքը մեծ է ներկայիս մեծագույնից՝ թարմացնում ենք
        if (RightIndex < size && arr[RightIndex] > arr[LargestIndex])
        {
            LargestIndex = RightIndex;
        }

        // Եթե մեծագույն ինդեքսը փոխվել է, նշանակում է պետք է տեղերը փոխենք
        // If the largest is not the parent node, swap and continue heapifying
        if (LargestIndex != i)
        {
            // Փոխում ենք մեծագույնը ներկայիս ինդեքսի հետ
            Swap(arr, i, LargestIndex);

            // Կրկին կարգավորում ենք subtree-ն նոր ինդեքսից
            // Recursively heapify the affected sub-tree
            Heapify(arr, LargestIndex, size);
        }
    }

    private static void BuildMaxHeap(int[] arr)// Builds a Max-Heap from the unsorted array
    {
        int size = arr.Length;

        // Start from the last non-leaf node and go up to the root
        // All leaf nodes are already heaps, so we skip them
        // Սկսում ենք heapify անել ներքևից դեպի վեր՝ ոչ տերևային (non-leaf) ինդեքսներից
        // Վերջին non-leaf էլեմենտը գտնվում է (size / 2) - 1 ինդեքսում
        for (int i = (size / 2) - 1; i >= 0; --i)
        {
            Heapify(arr, i, size);
        }
    }
}
