using System;

class Sorting
{
    private static void Swap(int[] arr, int i, int j)
    {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }
    private static int FirstPivot(int[] arr, int left, int right)
    {
        int pivot = arr[left];
        int i = left + 1;
        int j = right;
        while (i <= j)
        {
            while (i <= j && arr[i] <= pivot)
            {
                ++i;
            }
            while (j >= i && arr[j] > pivot)
            {
                --j;
            }
            if (i < j)
            {
                Swap(arr, i, j);   
            }
            
        }
        Swap(arr, pivot, j);
        return j;
    }

    public static void QuickSort(int[] arr, int left, int right)
    {
        if (arr == null)
        {
             throw new ArgumentNullException("Input array cannot be null.");
        }
        if (left < 0 || right >= arr.Length || left > right)
        {
             throw new ArgumentOutOfRangeException("Invalid left or right indices");   
        }
        if (left < right)
        {
            int pivotindex = FirstPivot(arr, left, right);
            QuickSort(arr, left, pivotindex - 1);
            QuickSort(arr, pivotindex + 1, right);
        }
    }
}
