using System;

class Program
{
    static void Main()
    {

        int[] arr = { 11, 17, 23, 38, 49, 56, 64, 71, 83, 102 };

        // Lunghezza dell'array
        int n = arr.Length;

        // Elemento da cercare nell'array
        int x = 102;

        // Esegui la ricerca binaria sull'array
        int risultato = binarySearch(arr, 0, n - 1, x);

        // Stampa il risultato
        if (risultato == -1)
        {
            Console.WriteLine("Elemento non trovato");
        }
        else 
        { 
            Console.WriteLine("Elemento trovato; Index " + risultato);
        }

        Console.ReadLine();
    }

    // Funzione di ricerca binaria
    static int binarySearch(int[] arr, int sx, int dx, int x)
    {
        if (dx >= sx)
        {
            int mid = sx + (dx - sx) / 2;

            // Controlla se l'elemento al centro è uguale a x
            if (arr[mid] == x)
            {
                return mid;
            }
            // Se l'elemento al centro è maggiore di x, cerca nella metà sinistra
            else if (arr[mid] > x)
            {
                return binarySearch(arr, sx, mid - 1, x);
            }
            // Se l'elemento al centro è minore di x, cerca nella metà destra
            else
            {
                return binarySearch(arr, mid + 1, dx, x);
            }
        }

        // Se l'elemento non è presente nell'array, restituisci -1
        return -1;
    }
}

// notazione asintotica Big, Theta e Omega sono tutte log (n) = logaritmica
