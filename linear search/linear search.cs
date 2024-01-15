using System;

class Program
{
    static void Main()
    {
       
        int[] arr = { 45, 17, 82, 34, 68, 21, 53, 79, 26, 93 };

       
        int n = arr.Length;

        // Elemento da cercare nell'array
        int key = 45;

        // Indice in cui è stato trovato l'elemento. -1 significa non trovato
        int pos = -1;

        // Ciclo attraverso l'array
        for (int i = 0; i < n; i++)
        {
            // Controlla se l'elemento corrente è uguale alla chiave di ricerca
            if (arr[i] == key)
            {
                // Se è uguale, imposta l'indice e interrompi il ciclo
                pos = i;
                break;
            }
        }

        // Stampa il risultato in base all'indice trovato
        if (pos != -1)
        {
            Console.WriteLine($"L'elemento {key} è stato trovato in posizione {pos}");
        }
        else
        {
            Console.WriteLine("Elemento non trovato");
        }
    }
}
// notazione asintotica Big O, Theta e Omega è lineare
