using System;

class Program
{
    static void Main()
    {
        int n = 5; // Numero di gradini nella scala
        int modiUnici = ModiUniciSalitaScala(n);

        Console.WriteLine($"Il numero di modi unici per salire una scala di {n} gradini è: {modiUnici}");
    }

    static int ModiUniciSalitaScala(int n)
    {
        if (n <= 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        int[] modi = new int[n + 1];

        // Ci sono 1 modo per salire 1 gradino
        modi[1] = 1;

        // Ci sono 2 modi per salire 2 gradini: (1, 1) o (2)
        modi[2] = 2;

        // Calcola il numero di modi unici per salire i gradini rimanenti utilizzando la programmazione dinamica
        for (int i = 3; i <= n; i++)
        {
            modi[i] = modi[i - 1] + modi[i - 2];
        }

        return modi[n];
    }
}
