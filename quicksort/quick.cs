using System;

class Program
{
    static void Main()
    {
        int[] arr = { 37, 15, 92, 64, 28, 51, 19, 73, 46, 84 };
        Quicksort(arr);

        
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
    }

    static void Quicksort(int[] arr)
    {
        Quicksort(arr, 0, arr.Length - 1);
    }

    static void Quicksort(int[] arr, int a, int b)
    {
        int i = a;
        int j = b;
        int pivot = arr[(a + b) / 2];

        while (i <= j)
        {
            while (arr[i] < pivot)
            {
                i++;
            }

            while (arr[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
        }

        if (a < j)
        {
            Quicksort(arr, a, j);
        }

        if (i < b)
        {
            Quicksort(arr, i, b);
        }
    }
}
// notazione O (n al quadrato) = esponenziale 
