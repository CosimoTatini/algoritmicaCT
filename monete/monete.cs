using System;

class Program
{
    static void Main()
    {
        int amount = 6; // L'importo per il quale calcolare il cambio minimo
        int[] cambio = CambioMinimo(amount);

        Console.WriteLine($"Il cambio minimo per {amount} centesimi è:");

        for (int i = 0; i < cambio.Length; i++)
        {
            Console.WriteLine($"{cambio[i]} moneta(i) da {GetTaglio(i)} centesimi");
        }
    }

    static int[] CambioMinimo(int amount)
    {
        int[] tagliMonete = { 4, 3, 1 }; // Monete disponibili con i relativi tagli
        int[] cambio = new int[tagliMonete.Length];

        for (int i = 0; i < tagliMonete.Length; i++)
        {
            cambio[i] = amount / tagliMonete[i];
            amount %= tagliMonete[i];
        }

        return cambio;
    }

    static int GetTaglio(int index)
    {
        // Restituisce il valore del taglio in base all'indice nell'array tagliMonete
        switch (index)
        {
            case 0: return 4;
            case 1: return 3;
            case 2: return 1;
            default: return 0;
        }
    }
}
