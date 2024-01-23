using System;

class Program
{
    static void Main()
    {
        int[] array = { 4, 2, 7, 1, 9, 5, 3 };

        Console.WriteLine("Array prima dell'ordinamento:");
        StampaArray(array);

        QuickSort(array, 0, array.Length - 1);

        Console.WriteLine("\nArray dopo l'ordinamento:");
        StampaArray(array);
    }

    // Funzione principale per l'algoritmo di Quick Sort
    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Trova l'indice di partizione, gli elementi minori a sinistra, quelli maggiori a destra
            int partitionIndex = Partition(array, low, high);

            // Applica ricorsivamente QuickSort alle due parti dell'array
            QuickSort(array, low, partitionIndex - 1);
            QuickSort(array, partitionIndex + 1, high);
        }
    }

    // Funzione di partizione: sceglie un pivot, riorganizza l'array e restituisce l'indice di partizione
    static int Partition(int[] array, int low, int high)
    {
        // Sceglie il pivot (nel nostro caso, l'elemento più a destra)
        int pivot = array[high];

        // Inizializza l'indice dell'elemento più piccolo
        int i = low - 1;

        // Scorre l'array
        for (int j = low; j < high; j++)
        {
            // Se l'elemento corrente è minore del pivot, lo scambia con l'elemento più a sinistra
            if (array[j] < pivot)
            {
                i++;
                Scambia(array, i, j);
            }
        }

        // Scambia l'elemento successivo dopo quelli più piccoli con il pivot
        Scambia(array, i + 1, high);

        // Restituisce l'indice di partizione
        return i + 1;
    }

    // Funzione per scambiare due elementi nell'array
    static void Scambia(int[] array, int index1, int index2)
    {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    // Funzione per stampare l'array
    static void StampaArray(int[] array)
    {
        foreach (var elemento in array)
        {
            Console.Write(elemento + " ");
        }
        Console.WriteLine();
    }
}
