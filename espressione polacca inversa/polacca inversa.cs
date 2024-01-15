using System;

public class NodoEspressione
{
    public string Valore;
    public NodoEspressione Sinistro;
    public NodoEspressione Destro;

    public NodoEspressione(string valore)
    {
        Valore = valore;
        Sinistro = null;
        Destro = null;
    }
}

public class AlberoEspressione
{
    public NodoEspressione Radice;

    public AlberoEspressione() { Radice = null; }
}

public class EspressionePolaccaInversa
{
    public static AlberoEspressione CostruisciAlbero(string espressione)
    {
        AlberoEspressione albero = new AlberoEspressione();
        Stack<NodoEspressione> stack = new Stack<NodoEspressione>();

        string[] tokens = espressione.Split(' ');

        foreach (string token in tokens)
        {
            if (IsOperatore(token))
            {
                // Operatore: pop (rimuove) due operandi dallo stack, crea un nodo operatore e reinserisce nello stack
                NodoEspressione operatore = new NodoEspressione(token);
                operatore.Destro = stack.Pop();
                operatore.Sinistro = stack.Pop();
                stack.Push(operatore);
            }
            else
            {
                // Operando: creare un nodo e inserire nello stack
                stack.Push(new NodoEspressione(token));
            }
        }

        // Alla fine, lo stack conterrà solo la radice dell'albero
        albero.Radice = stack.Pop();

        return albero;
    }

    private static bool IsOperatore(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }
}

public class ValutatoreEspressione
{
    public static int ValutaEspressione(AlberoEspressione albero)
    {
        return ValutaNodo(albero.Radice);
    }

    private static int ValutaNodo(NodoEspressione nodo)
    {
        if (nodo == null)
        {
            throw new ArgumentNullException(nameof(nodo));
        }

        // Se il nodo è un operando, convertilo in int e restituiscilo
        if (!IsOperatore(nodo.Valore))
        {
            return int.Parse(nodo.Valore);
        }

        // Se il nodo è un operatore, valuta i risultati dei sottoalberi sinistro e destro
        int sinistro = ValutaNodo(nodo.Sinistro);
        int destro = ValutaNodo(nodo.Destro);

        // Esegui l'operazione in base all'operatore
        switch (nodo.Valore)
        {
            case "+":
                return sinistro + destro;
            case "-":
                return sinistro - destro;
            case "*":
                return sinistro * destro;
            case "/":
                return sinistro / destro;
            default:
                throw new ArgumentException($"Operatore non supportato: {nodo.Valore}");
        }
    }

    private static bool IsOperatore(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }
}

class Program
{
    static void Main()
    {
        // Esempio di utilizzo
        string espressionePolaccaInversa = "3 4 + 2 *";
        AlberoEspressione albero = EspressionePolaccaInversa.CostruisciAlbero(espressionePolaccaInversa);

        // Valuta l'espressione e stampa il risultato
        int risultato = ValutatoreEspressione.ValutaEspressione(albero);
        Console.WriteLine($"Il risultato dell'espressione è: {risultato}");
    }
}
