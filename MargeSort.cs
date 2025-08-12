class MargeSorting
{
    public static void MyMargeSort(int[] arr, int left, int right)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("Input array cannot be null.");
        }
        if (arr.Length <= 1 || left >= right)
        {
            return; // No needed sorting empty or Single arr because single already sorted 
        }
        if (left < 0 || right >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("Indices are out of bounds.");
        } 
        if (left >= right)
        {
            return;
        }

        int mid = left + (right - left) / 2;
        MyMargeSort(arr, left, mid);
        MyMargeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }
    private static void Merge(int[] arr, int left, int mid, int right)
    {
        int l1 = left;
        int r1 = mid;
        int l2 = mid + 1;
        int r2 = right;
        List<int> tmp = new List<int>();
        while (l1 <= r1 && l2 <= r2)
        {
            if (arr[l1] <= arr[l2])
            {
                tmp.Add(arr[l1++]);
            }
            else
            {
                tmp.Add(arr[l2++]);
            }
        }
        while (l1 <= r1)
        {
            tmp.Add(arr[l1++]);
        }
        while (l2 <= r2)
        {
            tmp.Add(arr[l2++]);
        }
        for (int i = 0; i < tmp.Count; ++i)
        {
            arr[left++] = tmp[i];
        }
    }
}
class Program
{
    static void Main()// Chat test Main
    {
        // Test case 1: Normal unsorted array
        int[] arr1 = { 5, 2, 9, 1, 5, 6 };
        MargeSorting.MyMargeSort(arr1, 0, arr1.Length - 1);
        Console.WriteLine("Sorted arr1: " + string.Join(", ", arr1));

        // Test case 2: Already sorted array
        int[] arr2 = { 1, 2, 3, 4, 5 };
        MargeSorting.MyMargeSort(arr2, 0, arr2.Length - 1);
        Console.WriteLine("Sorted arr2: " + string.Join(", ", arr2));

        // Test case 3: Reverse sorted array
        int[] arr3 = { 9, 7, 5, 3, 1 };
        MargeSorting.MyMargeSort(arr3, 0, arr3.Length - 1);
        Console.WriteLine("Sorted arr3: " + string.Join(", ", arr3));

        // Test case 4: Array with one element
        int[] arr4 = { 42 };
        MargeSorting.MyMargeSort(arr4, 0, arr4.Length - 1);
        Console.WriteLine("Sorted arr4: " + string.Join(", ", arr4));

        // Test case 5: Empty array
        int[] arr5 = { };
        MargeSorting.MyMargeSort(arr5, 0, arr5.Length - 1);
        Console.WriteLine("Sorted arr5: " + string.Join(", ", arr5));

        // Test case 6: Array with duplicates
        int[] arr6 = { 3, 1, 2, 3, 1, 2 };
        MargeSorting.MyMargeSort(arr6, 0, arr6.Length - 1);
        Console.WriteLine("Sorted arr6: " + string.Join(", ", arr6));

        // Test case 7: null array
        try
        {
            int[]? arr7 = null;
            MargeSorting.MyMargeSort(arr7!, 0, 0);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Null test passed: " + ex.Message);
        }

        // Test case 8: Invalid indices
        try
        {
            int[] arr8 = { 1, 2, 3 };
            MargeSorting.MyMargeSort(arr8, -1, 5);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Index range test passed: " + ex.Message);
        }
    }
}
