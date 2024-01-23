using System;

class Program
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int target = 6;

        int risultato = RicercaBinaria(array, target);

        if (risultato != -1)
        {
            Console.WriteLine($"L'elemento {target} si trova all'indice {risultato} nell'array.");
        }
        else
        {
            Console.WriteLine($"L'elemento {target} non è presente nell'array.");
        }
    }

    static int RicercaBinaria(int[] array, int target)
    {
        int sinistra = 0;
        int destra = array.Length - 1;

        while (sinistra <= destra)
        {
            int medio = sinistra + (destra - sinistra) / 2;

            // Controlla se l'elemento è presente al centro
            if (array[medio] == target)
            {
                return medio;
            }

            // Se l'elemento è più piccolo, ignora la metà destra
            if (array[medio] > target)
            {
                destra = medio - 1;
            }
            // Se l'elemento è più grande, ignora la metà sinistra
            else
            {
                sinistra = medio + 1;
            }
        }

        // Se l'elemento non è presente nell'array
        return -1;
    }
}
