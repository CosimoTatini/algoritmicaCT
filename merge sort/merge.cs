using System;

class Program
{
    static void Main()
    {
        int[] arr = { 53, 29, 87, 14, 68, 42, 95, 71, 36, 60 };
        MergeSort(arr);

        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }

        Console.ReadLine();
    }

    static void MergeSort(int[] arr)
    {
        MergeSort(arr, 0, arr.Length - 1);
    }

    static void MergeSort(int[] arr, int a, int c)
    {
        if (a < c)
        {
            int b = (a + c) / 2;
            MergeSort(arr, a, b);
            MergeSort(arr, b + 1, c);
            Merge(arr, a, b, c);
        }
    }

    static void Merge(int[] arr, int a, int b, int c)
    {
        int[] temp = new int[c - a + 1];
        int i = a;
        int j = b + 1;
        int k = 0;

        while (i <= b && j <= c)
        {
            if (arr[i] < arr[j])
            {
                temp[k] = arr[i];
                i++;
            }
            else
            {
                temp[k] = arr[j];
                j++;
            }
            k++;
        }

        while (i <= b)
        {
            temp[k] = arr[i];
            i++;
            k++;
        }

        while (j <= c)
        {
            temp[k] = arr[j];
            j++;
            k++;
        }

        for (i = a; i <= c; i++)
        {
            arr[i] = temp[i - a];
        }
    }
}
