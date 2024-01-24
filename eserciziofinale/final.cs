// Array dato
int[] arr = { 10, 15, 15, 20, 25, 25, 30, 35, 35, 40 };

// Array bidimensionale per memorizzare gli elementi e le loro frequenze
int[][] arrtemp = new int[arr.Length][];
int max = 0;

// Inizializza l'array bidimensionale con valori predefiniti
for (int i = 0; i < arr.Length; i++)
{
    arrtemp[i] = new int[2];
    arrtemp[i][0] = -1; // Elemento
    arrtemp[i][1] = 0;  // Frequenza
}

// Itera sull'array dato
for (int j = 0; j < arr.Length; j++)
{
    bool trovato = false;

    // Verifica se l'elemento è già presente nell'array arrtemp
    for (int i = 0; i < arr.Length; i++)
    {
        if (arrtemp[i][0] == arr[j])
        {
            arrtemp[i][1]++;  // Incrementa la frequenza
            trovato = true;
            break;
        }
    }

    // Se l'elemento non è stato trovato in arrtemp, aggiungilo all'array
    if (!trovato)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arrtemp[i][0] == -1)
            {
                arrtemp[i][0] = arr[j];  // Aggiunge l'elemento
                arrtemp[i][1]++;         // Incrementa la frequenza
                Console.WriteLine(arrtemp[i][0]);  // Stampa l'elemento aggiunto
                break;
            }
        }
    }
}

// Visualizza gli elementi e le loro frequenze memorizzati in arrtemp
for (int i = 0; i < arrtemp.Length; i++)
{
    if (max < arrtemp[i][1])
        max = arrtemp[i][1];
    Console.WriteLine($"{arrtemp[i][0]} - {arrtemp[i][1]}"); // stampa delle frequenze
}

// Visualizza la frequenza massima
Console.WriteLine($"Frequenza massima: {max}");
