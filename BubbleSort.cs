using System;
using System.Globalization;

class BooblSorting
{
    public static void BooblSort(int[] arr)
    {
        int size = arr.Length - 1;
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size - i; ++j)
            {
                if (arr[j] > arr[j - 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }

    }
}
