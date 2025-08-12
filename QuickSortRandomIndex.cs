using System;

class Sorting
{
    private static void Swap(int[] arr, int i, int j)
    {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }
    private static int RandomPivot(int[] arr, int left, int right)
    {
        Random random = new Random();
        int pivotindex = random.Next(left, right + 1);
        int i = left - 1;
        int pivot = arr[right];
        Swap(arr, right, pivot);
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
            int pivotindex = RandomPivot(arr, left, right);
            QuickSort(arr, left, pivotindex - 1);
            QuickSort(arr, pivotindex + 1, right);
        }
    }
}
