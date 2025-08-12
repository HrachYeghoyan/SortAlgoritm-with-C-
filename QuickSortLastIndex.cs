using System;
public class Sorting
{
    private static void Swap(int[] arr, int i, int j)
    {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }
    private static int LastPivot(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;
        for (int j = left; i < right; ++j)
        {
            if (arr[j] < pivot)
            {
                ++i;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, pivot);
        return i + 1;
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
            int pivotindex = LastPivot(arr, left, right);
            QuickSort(arr, left, pivotindex - 1);
            QuickSort(arr, pivotindex + 1, right);
        }
    }
}
