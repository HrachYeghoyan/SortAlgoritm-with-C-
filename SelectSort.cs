using System;

public class SelectionSort
{
    public static void MySelectionSort(int[] arr)
    {
        int size = arr.Length;
        for (int i = 0; i < size - 1; ++i)
        {
            int minindex = i;// yntrum enq vorpes amena poqr element 
            for (int j = i + 1; j < size; ++j)// pntrum enq amena poqr elementy amboxj zangvatum
            {
                if (arr[j] < arr[minindex])
                {
                    minindex = j;// gtnum enq irakan amena poqr elementy 
                }
            }
            int tmp = arr[minindex];// poxum enq amenapoqr elementy zangvatsi chsortavorvats masi araji elementi het interaciai skzbum da zagvatsi araji elementn e hajordic sksats ayn poxvum e hajordin depi aj 
            arr[minindex] = arr[i];
            arr[i] = tmp;
        }
    }
}
