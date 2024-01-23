using System;

class Program
{
    static void Main()
    {
        
        int[] start = { 1, 3, 0, 5, 8, 5 };
        int[] finish = { 2, 4, 6, 7, 9, 9 };

        // Chiamata alla funzione per la selezione delle attività compatibili
        int[] attivitaSelezionate = SelezioneAttivita(start, finish);

        // Stampa le attività selezionate
        Console.WriteLine("Attività selezionate:");
        for (int i = 0; i < attivitaSelezionate.Length; i++)
        {
            if (attivitaSelezionate[i] == 1)
            {
                Console.WriteLine($"Attività {i + 1} (inizio: {start[i]}, fine: {finish[i]})");
            }
        }
    }

    // Funzione che implementa l'algoritmo greedy per la selezione delle attività
    static int[] SelezioneAttivita(int[] start, int[] finish)
    {
        int n = start.Length;

        // Ordina le attività in base al tempo di fine
        OrdinaPerFine(start, finish);

        // Array per memorizzare se un'attività è stata selezionata (1) o meno (0)
        int[] attivitaSelezionate = new int[n];
        attivitaSelezionate[0] = 1; // La prima attività viene sempre selezionata

        int j = 0;

        // Scorri le attività e seleziona quelle compatibili
        for (int i = 1; i < n; i++)
        {
            if (start[i] >= finish[j])
            {
                attivitaSelezionate[i] = 1; // Seleziona l'attività
                j = i; // Aggiorna l'indice dell'attività selezionata
            }
        }

        return attivitaSelezionate;
    }

    // Funzione per ordinare le attività in base al tempo di fine
    static void OrdinaPerFine(int[] start, int[] finish)
    {
        int n = start.Length;

        for (int i = 1; i < n; i++)
        {
            int keyFinish = finish[i];
            int keyStart = start[i];
            int j = i - 1;

            // Ordinamento delle attività in base al tempo di fine utilizzando l'algoritmo di inserimento
            while (j >= 0 && finish[j] > keyFinish)
            {
                finish[j + 1] = finish[j];
                start[j + 1] = start[j];
                j = j - 1;
            }

            finish[j + 1] = keyFinish;
            start[j + 1] = keyStart;
        }
    }
}
