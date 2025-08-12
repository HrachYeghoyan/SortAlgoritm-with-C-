using System;
using System.Collections;
using System.Collections.Generic;

namespace SortingAlgorithm
{
    public class Counting
    {
        public static int[] CountSort(int[] arr)
        {
            if (arr == null || arr.Length == 0) return arr!;// checking for null or empty array 
            int min = arr[0];
            int max = arr[0];
            for (int i = 0; i < arr.Length; ++i)// 1 Stpe: Find the minimum and maximum elements in the input array
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }

            int size = max - min + 1;//2 Step: mijakayqi chapn enq hashvum
            int[] count = new int[size];//3 Step:creating new count array with size

            for (int i = 0; i < arr.Length; ++i)// hashvum enq te qani angam e handipum ayd elmenty zangvatsum
            {
                count[arr[i] - min]++;// ogtagortsum enq shiftingi gaxapary or -100 klini 0 index
            }
            for (int i = 1; i < size; ++i)// stextsum enq prefix sum
            {
                count[i] += count[i - 1];
            }
            int[] output = new int[arr.Length];// creating output array 
            for (int i = arr.Length - 1; i >= 0; --i)
            {
                int number = arr[i];// yntacik arjeqn e input zangvatsi   // Current element from input array
                int index = number - min;//shiftingov hashvats indexn e count i hamar  //  Shifted index in count array
                count[index]--;// nvazecnum enq qani hat arden texadrel enq  // Decrease the count, since we're placing one
                int sortindex = count[index];//ays arjeqy petq e dnel ays indexum output zangvatsum // Get the index in output array
                output[sortindex] = number;//texadrum enq irakan arjeqy sortavorvats zangvatsum // Place the number in the sorted array
                //output[count[arr[i] - min] - 1] = arr[i];
                //count[arr[i] - min]--;
            }

            return output;

        }
    }
}
