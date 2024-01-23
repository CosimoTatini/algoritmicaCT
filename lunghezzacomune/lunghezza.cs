using System;

class Program
{
    static void Main()
    {
        string s1 = "Barchetta";
        string s2 = "Mela";

        int lunghezzaSottosequenza = LunghezzaSottosequenzaComune(s1, s2);

        Console.WriteLine($"La lunghezza della più lunga sottosequenza comune è: {lunghezzaSottosequenza}");
    }

    static int LunghezzaSottosequenzaComune(string s1, string s2)
    {
        int m = s1.Length;
        int n = s2.Length;

        // Creazione di una matrice per memorizzare le lunghezze delle sottosequenze comuni
        int[,] dp = new int[m + 1, n + 1];

        // Riempimento della matrice utilizzando la programmazione dinamica
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        // Il valore nell'angolo in basso a destra della matrice contiene la lunghezza della più lunga sottosequenza comune
        return dp[m, n];
    }
}
